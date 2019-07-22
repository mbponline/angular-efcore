using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;
using System.Threading.Tasks;
using AutoMapper;
using ProAgil.WebAPI.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Linq;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //post dados são esperados no body da requisição
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repository;
        private readonly IMapper _mapper;

        public EventoController(IProAgilRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try

            {
                var eventos = await _repository.GetAllEventoAsync(true);
                var result = _mapper.Map<IEnumerable<EventoDto>>(eventos);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpPost("upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", "").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                }
                return Ok();

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro upload imagem {ex.Message}");

            }
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var evento = await _repository.GetEventoAsyncById(EventoId, true);
                var result = _mapper.Map<EventoDto>(evento);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var evento = await _repository.GetAllEventoAsyncByTema(tema, true);
                var result = _mapper.Map<IEnumerable<EventoDto>>(evento);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _repository.Add(evento);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/evento/{evento.Id}", _mapper.Map<EventoDto>(evento));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        //PUT
        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, EventoDto model)
        {
            try
            {
                var evento = await _repository.GetEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();

                var idLotes = new List<int>();
                model.Lotes.ForEach(item => idLotes.Add(item.Id));

                var idRedesSociais = new List<int>();
                model.RedesSociais.ForEach(item => idRedesSociais.Add(item.Id));

                var lotes = evento.Lotes.Where(
                    lote => !idLotes.Contains(lote.Id)).ToArray();

                var redesSociais = evento.RedesSociais.Where(
                    rede => !idRedesSociais.Contains(rede.Id)).ToArray();

                if (lotes.Length > 0) _repository.Delete(lotes);

                if (redesSociais.Length > 0) _repository.Delete(redesSociais);

                _mapper.Map(model, evento);

                _repository.Update(evento);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(model));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        //DELETE
        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repository.GetEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();
                _repository.Delete(evento);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

    }
}
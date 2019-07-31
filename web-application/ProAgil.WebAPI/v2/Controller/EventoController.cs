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

namespace ProAgil.WebAPI.v2.Controllers
{

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository<Evento> _repository;
        private readonly IMapper _mapper;

        public EventoController(IProAgilRepository<Evento> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Getv20()
        {
            try
            {
                var eventos = await _repository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<EventoDto>>(eventos);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet]
        // para acessar essa url deve-se no header da requisição adicionar
        // key -> x-api-version Value -> 3
        [MapToApiVersion("3")]
        public async Task<IActionResult> Get21()
        {
            try
            {
                var eventos = await _repository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<EventoDto>>(eventos);
                return NotFound();
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

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var evento = await _repository.GetByIdAsync(eventoId);
                var result = _mapper.Map<EventoDto>(evento);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet("getByTema/{eventoTema}")]
        public async Task<IActionResult> Get(string eventoTema)
        {
            try
            {
                var evento = await _repository.GetAllByNameAsync(eventoTema);
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
                if (await _repository.SaveChanges())
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
        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _repository.GetByIdAsync(eventoId);
                _mapper.Map(model, evento);

                _repository.Update(evento);
                if (await _repository.SaveChanges())
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
        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var evento = await _repository.GetByIdAsync(eventoId);
                if (evento == null) return NotFound();
                _repository.Remove(evento.Id);
                if (await _repository.SaveChanges())
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
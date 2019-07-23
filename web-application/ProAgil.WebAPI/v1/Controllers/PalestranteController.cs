using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repository;

        private readonly IMapper _mapper;

        public PalestranteController(IProAgilRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var palestrantes = await _repository.GetAllPalestrantesAsync(true);
                var result = _mapper.Map<IEnumerable<PalestranteDto>>(palestrantes);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId)
        {
            try
            {
                var palestrante = await _repository.GetPalestranteAsyncById(palestranteId, true);
                var result = _mapper.Map<PalestranteDto>(palestrante);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet("getByName/{palestranteNome}")]
        public async Task<IActionResult> Get(string palestranteNome)
        {
            try
            {
                var palestrante = await _repository.GetAllPalestrantesAsyncByName(palestranteNome, true);
                var result = _mapper.Map<PalestranteDto>(palestrante);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PalestranteDto model)
        {
            try
            {
                var palestrante = _mapper.Map<Palestrante>(model);
                _repository.Add(palestrante);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{palestrante.Id}", _mapper.Map<PalestranteDto>(palestrante));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{palestranteId}")]
        public async Task<IActionResult> Put(int palestranteId, PalestranteDto model)
        {
            try
            {
                var palestrante = await _repository.GetPalestranteAsyncById(palestranteId, false);
                if (palestrante == null) return NotFound();

                var idRedesSociais = new List<int>();
                model.RedesSociais.ForEach(item => idRedesSociais.Add(item.Id));

                var redesSociais = palestrante.RedesSociais.Where(
                    rede => !idRedesSociais.Contains(rede.Id)).ToArray();

                if (redesSociais.Length > 0) _repository.Delete(redesSociais);

                _mapper.Map(model, palestrante);

                _repository.Update(palestrante);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", _mapper.Map<PalestranteDto>(model));
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{palestranteId}")]
        public async Task<IActionResult> Delete(int palestranteId)
        {

            try
            {
                var palestrante = await _repository.GetPalestranteAsyncById(palestranteId, false);
                if (palestrante == null) return NotFound();
                _repository.Delete(palestrante);
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
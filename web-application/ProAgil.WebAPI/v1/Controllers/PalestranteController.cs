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
        private readonly IProAgilRepository<Palestrante> _repository;

        private readonly IMapper _mapper;

        public PalestranteController(IProAgilRepository<Palestrante> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var palestrantes = await _repository.GetAllAsync();
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
                var palestrante = await _repository.GetByIdAsync(palestranteId);
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
                var palestrante = await _repository.GetAllByNameAsync(palestranteNome);
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
                if (await _repository.SaveChanges())
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
                var palestrante = await _repository.GetByIdAsync(palestranteId);
                if (palestrante == null) return NotFound();

                var idRedesSociais = new List<int>();
                model.RedesSociais.ForEach(item => idRedesSociais.Add(item.Id));

                var redesSociais = palestrante.RedesSociais.Where(
                    rede => !idRedesSociais.Contains(rede.Id)).ToArray();

                if (redesSociais.Length > 0) _repository.Remove(redesSociais);

                _mapper.Map(model, palestrante);

                _repository.Update(palestrante);
                if (await _repository.SaveChanges())
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
                var palestrante = await _repository.GetByIdAsync(palestranteId);
                if (palestrante == null) return NotFound();
                _repository.Remove(palestrante.Id);
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
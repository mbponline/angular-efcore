using System.Collections.Generic;
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
    public class LoteController : ControllerBase
    {
        private readonly IProAgilRepository<Lote> _repository;
        private readonly IMapper _mapper;

        public LoteController(IProAgilRepository<Lote> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lotes = await _repository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<LoteDto>>(lotes);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet("{loteId}")]
        public async Task<IActionResult> Get(int loteId)
        {
            try
            {
                var lote = await _repository.GetByIdAsync(loteId);
                var result = _mapper.Map<LoteDto>(lote);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }


        [HttpGet("getByNomeLote/{loteName}")]
        public async Task<IActionResult> Get(string loteName)
        {
            try
            {
                var lotes = await _repository.GetAllByNameAsync(loteName);
                var result = _mapper.Map<IEnumerable<LoteDto>>(lotes);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoteDto model)
        {
            try
            {
                var lote = _mapper.Map<Lote>(model);
                _repository.Add(lote);
                if (await _repository.SaveChanges())
                {
                    return Created($"/api/lote/{lote.Id}", _mapper.Map<LoteDto>(lote));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{loteId}")]
        public async Task<IActionResult> Put(int loteId, LoteDto model)
        {
            try
            {
                var lote = await _repository.GetByIdAsync(loteId);
                if (lote == null) return NotFound();

                _mapper.Map(model, lote);

                _repository.Update(lote);
                if (await _repository.SaveChanges())
                {
                    return Created($"/api/lote/{model.Id}", _mapper.Map<LoteDto>(model));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        //DELETE
        [HttpDelete("{loteId}")]
        public async Task<IActionResult> Delete(int loteId)
        {
            try
            {
                var lote = await _repository.GetByIdAsync(loteId);
                if (lote == null) return NotFound();
                _repository.Remove(lote.Id);
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
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
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly IProAgilRepository _repository;
        private readonly IMapper _mapper;

        public LoteController(IProAgilRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lotes = await _repository.GetAllLotesAsync();
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
                var lote = await _repository.GetLoteAsyncById(loteId);
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
                var lotes = await _repository.GetAllLotesAsyncByName(loteName);
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
                if (await _repository.SaveChangesAsync())
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
                var lote = await _repository.GetLoteAsyncById(loteId);
                if (lote == null) return NotFound();

                _mapper.Map(model, lote);

                _repository.Update(lote);
                if (await _repository.SaveChangesAsync())
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
                var lote = await _repository.GetLoteAsyncById(loteId);
                if (lote == null) return NotFound();
                _repository.Delete(lote);
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
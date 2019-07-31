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
    public class RedeSocialController : ControllerBase
    {
        private readonly IProAgilRepository<RedeSocial> _repository;
        private readonly IMapper _mapper;

        public RedeSocialController(IProAgilRepository<RedeSocial> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var redesSociais = await _repository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<RedeSocialDto>>(redesSociais);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpGet("{redeSocialId}")]
        public async Task<IActionResult> Get(int redeSocialId)
        {
            try
            {
                var redeSocial = await _repository.GetByIdAsync(redeSocialId);
                var result = _mapper.Map<RedeSocialDto>(redeSocial);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }


        [HttpGet("getByNomeRedeSocial/{redeSocialName}")]
        public async Task<IActionResult> Get(string redeSocialName)
        {
            try
            {
                var redesSociais = await _repository.GetAllByNameAsync(redeSocialName);
                var result = _mapper.Map<IEnumerable<RedeSocialDto>>(redesSociais);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RedeSocialDto model)
        {
            try
            {
                var redeSocial = _mapper.Map<RedeSocial>(model);
                _repository.Add(redeSocial);
                if (await _repository.SaveChanges())
                {
                    return Created($"/api/redeSocial/{redeSocial.Id}", _mapper.Map<RedeSocialDto>(redeSocial));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{redeSocialId}")]
        public async Task<IActionResult> Put(int redeSocialId, RedeSocialDto model)
        {
            try
            {
                var redeSocial = await _repository.GetByIdAsync(redeSocialId);
                if (redeSocial == null) return NotFound();

                _mapper.Map(model, redeSocial);

                _repository.Update(redeSocial);
                if (await _repository.SaveChanges())
                {
                    return Created($"/api/redeSocial/{model.Id}", _mapper.Map<RedeSocialDto>(model));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            }
            return BadRequest();
        }

        //DELETE
        [HttpDelete("{redeSocialId}")]
        public async Task<IActionResult> Delete(int redeSocialId)
        {
            try
            {
                var redeSocial = await _repository.GetByIdAsync(redeSocialId);
                if (redeSocial == null) return NotFound();
                _repository.Remove(redeSocial.Id);
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
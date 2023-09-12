using Emart_final.Models;
using Emart_final.Models.Repository.Configfolder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigRepository _repository;

        public ConfigController(IConfigRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Config>>> GetConfigs()
        {
            var configs = await _repository.GetAllConfigs();
            return Ok(configs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Config>> GetConfigById(int id)
        {
            var config = await _repository.GetConfigById(id);

            if (config == null)
            {
                return NotFound();
            }

            return Ok(config);
        }

        [HttpPost]
        public async Task<ActionResult<Config>> PostConfig(Config config)
        {
            var addedConfig = await _repository.AddConfig(config);
            return CreatedAtAction(nameof(GetConfigById), new { id = addedConfig.ConfigID }, addedConfig);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfig(int id, Config config)
        {
            if (id != config.ConfigID)
            {
                return BadRequest();
            }

            var updatedConfig = await _repository.UpdateConfig(id, config);

            if (updatedConfig == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfig(int id)
        {
            var configToDelete = await _repository.DeleteConfig(id);

            if (configToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

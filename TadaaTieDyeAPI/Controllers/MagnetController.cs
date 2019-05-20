using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TadaaTieDyeAPI.Controllers
{
    [Route("api/magnets")]
    [ApiController]
    public class MagnetController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public MagnetController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllMagnets()
        {
            try
            {
                var magnets = _repository.Magnets.GetAllMagnets();

                _logger.LogInfo($"Returned all magnets from database.");

                return Ok(magnets);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMagnets action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMagnetById(string id)
        {
            try
            {
                var magnet = _repository.Magnets.GetMagnetById(id);

                if (magnet.ProdId.Equals(String.Empty))
                {
                    _logger.LogError($"Magnet with id: {id}, hasn't been found in the database.");
                    return NotFound($"Magnet with id: {id}, hasn't been found in the database.");
                }
                else
                {
                    _logger.LogInfo($"returned magnet with id: {id}");
                    return Ok(magnet);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMagnetById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/cart")]
        public IActionResult GetMagnetsInACart(string id)
        {
            try
            {
                var magnet = _repository.Magnets.GetMagnetsInACart(id);

                if (magnet.ProdId.Equals(String.Empty))
                {
                    _logger.LogError($"Magnets with id: {id}, hasn't been found in the db.");
                    return NotFound($"Magnets with id: {id}, hasn't been found in the db.");
                }
                else
                {
                    _logger.LogInfo($"Returned magnet with details for id: {id}.");
                    return Ok(magnet);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMagnetsInACart action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
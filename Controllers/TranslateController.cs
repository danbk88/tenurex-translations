using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TranslationsService.Entities;
using TranslationsService.Entities.Models;
using TranslationsService.Managers;
using TranslationsService.Models;
using TranslationsService.Services;

namespace TranslationsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private readonly ITranslationService _translationService;
        private readonly ICacheService _cacheService;
        private readonly TranslateManager manager;
        private readonly ILogger _logger;

        public TranslateController(
           ITranslationService translationService,
           ICacheService cacheService,
           ILogger<TranslateController> logger
            )
        {
            _translationService = translationService;
            _cacheService = cacheService;
            _logger = logger;
            manager = new TranslateManager(_translationService, _cacheService);
            
        }

        [HttpGet]
        public async Task<IActionResult> translateAction([FromQuery] string phrase, [FromQuery] string from, [FromQuery] string to){
            try
            {
                if(from == String.Empty || from == null) {
                    return BadRequest("from is required");
                }
                if(to == String.Empty || to == null) {
                    return BadRequest("to is required");
                }
                if(phrase == String.Empty || phrase == null) {
                    return BadRequest("phrase is required");
                }
                
                if (!ModelState.IsValid) {
                    return BadRequest("Invalid model object");
                }
                TranslationResultData resData = await manager.translate(from, to, phrase);
                logInformation("Translation retrieved!");
                return Ok(resData);
            }
            catch (Exception ex)
            {
                logError($"Something went wrong inside the translate Action: {ex}");
                return StatusCode(500, "Internal server error");
            }

        }

        private void logInformation(string info)
        {
            _logger.LogInformation(info);
        }

        private void logError(string error)
        {
            _logger.LogError(error);
        }
    }
}   
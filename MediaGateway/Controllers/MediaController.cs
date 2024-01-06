using Microsoft.AspNetCore.Mvc;
using MediaGateway.Interfaces;
using MediaGateway.Processor;
using MediaGateway.Models;

namespace MediaGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly ILogger<MediaController> _logger;
        private IDocumentProcessor DocumentProcessor { get; set; }

        public MediaController(ILogger<MediaController> logger, IDocumentProcessor documentProcessor)
        {
            _logger = logger;
            DocumentProcessor = documentProcessor;
        }

        [HttpPost("SetMediaDocuments")]
        public async Task<IActionResult> SetMediaDocument([FromForm] Media media)
        {            
            await DocumentProcessor.SaveMediaDocument(media);
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MediaGateway.Interfaces;
using MediaGateway.Processor;

namespace MediaGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly ILogger<MediaController> _logger;
        private IDocumentProcessor DocumentProcessor { get; set; }

        public MediaController(ILogger<MediaController> logger, IBlobService blobService)
        {
            _logger = logger;
            DocumentProcessor = new DocumentProcessor(blobService);
        }

        [HttpPost("SetMediaDocuments")]
        public async Task<IActionResult> SetMediaDocument([FromForm] Media media)
        {            
            await DocumentProcessor.StoreMediaDocument(media);
            return Ok();
        }
    }
}
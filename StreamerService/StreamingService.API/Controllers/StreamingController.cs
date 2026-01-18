using Microsoft.AspNetCore.Mvc;
using StreamingService.Domain.Proxy;

namespace StreamingService.API.Controllers
{
    [ApiController]
    [Route("api/stream")]
    public class StreamingController : ControllerBase
    {
        private readonly IVideoStream _stream;
         

        public StreamingController(
            IVideoStream stream)
        {
            _stream = stream;
        } 

        [HttpGet("{contentId}")]
        public async Task<IActionResult> Stream(
            Guid contentId,
            [FromQuery] string device = "web")
        {

            var stream =
                await _stream.GetStreamAsync(
                    contentId,
                    Guid.NewGuid());

            return File(
                stream,
                "video/mp4",
                enableRangeProcessing: true);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Domain.Proxy
{
    public sealed class VideoStreamProxy : IVideoStream
    {
        private readonly IVideoStream _realStream;

        public VideoStreamProxy(
            IVideoStream realStream)
        {
            _realStream = realStream;
        }

        public async Task<Stream> GetStreamAsync(Guid contentId, Guid userId)
        {
            //if dont contain permitions return 

            Console.WriteLine("🔐 Proxy autorizou streaming");

            return await _realStream.GetStreamAsync(contentId, userId);
        }
    }
}

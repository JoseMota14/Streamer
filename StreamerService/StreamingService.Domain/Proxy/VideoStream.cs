using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Domain.Proxy
{
    public sealed class VideoStream : IVideoStream
    {
        public Task<Stream> GetStreamAsync(Guid contentId, Guid userId)
        {
            Console.WriteLine("📺 Streaming real iniciado");
            return Task.FromResult<Stream>(new MemoryStream());
        }
    }
}

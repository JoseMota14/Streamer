using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Domain.Proxy
{
    public interface IVideoStream
    {
        Task<Stream> GetStreamAsync(Guid contentId, Guid userId);
    }
}

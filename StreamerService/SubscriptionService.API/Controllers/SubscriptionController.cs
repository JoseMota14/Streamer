using Microsoft.AspNetCore.Mvc;
using SubscriptionService.API.Contracts;
using SubscriptionService.Application.Abstractions;
using SubscriptionService.Application.Commands;
using SubscriptionService.Application.DTOs;
using SubscriptionService.Application.Queries;

namespace SubscriptionService.API.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    public sealed class SubscriptionController : ControllerBase
    {
        private readonly ICommandHandler<SubscribeCommand> _subscribeHandler;
        private readonly ICommandHandler<SuspendSubscriptionCommand> _suspendHandler;
        private readonly IQueryHandler<GetSubscriptionQuery, SubscriptionDto> _getHandler;

        public SubscriptionController(
            ICommandHandler<SubscribeCommand> subscribeHandler,
            ICommandHandler<SuspendSubscriptionCommand> suspendHandler,
            IQueryHandler<GetSubscriptionQuery, SubscriptionDto> getHandler)
        {
            _subscribeHandler = subscribeHandler;
            _suspendHandler = suspendHandler;
            _getHandler = getHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(
            [FromBody] SubscribeRequest request,
            CancellationToken ct)
        {
            var command = new SubscribeCommand(
                request.UserId,
                request.UltraHd,
                request.OfflineDownload,
                request.ExtraProfiles);

            await _subscribeHandler.HandleAsync(command, ct);

            return Accepted();
        }

        [HttpPost("suspend")]
        public async Task<IActionResult> Suspend(
            [FromBody] SuspendSubscriptionRequest request,
            CancellationToken ct)
        {
            var command = new SuspendSubscriptionCommand(request.UserId);

            await _suspendHandler.HandleAsync(command, ct);

            return NoContent();
        }

        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<SubscriptionDto>> Get(
            Guid userId,
            CancellationToken ct)
        {
            var query = new GetSubscriptionQuery(userId);

            var result = await _getHandler.HandleAsync(query, ct);

            return Ok(result);
        }
    }

}

using SubscriptionService.Application.Abstractions;
using SubscriptionService.Application.Interfaces;
using SubscriptionService.Application.DTOs;
using SubscriptionService.Application.Mapping;

namespace SubscriptionService.Application.Queries
{
    public sealed class GetSubscriptionQueryHandler: IQueryHandler<GetSubscriptionQuery, SubscriptionDto>
    {
        private readonly ISubscriptionRepository _repository;

        public GetSubscriptionQueryHandler(
            ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubscriptionDto> HandleAsync(
            GetSubscriptionQuery query,
            CancellationToken ct)
        {
            var subscription =
                await _repository.GetByUserIdAsync(query.UserId, ct)
                ?? throw new InvalidOperationException("Subscription not found");

            return SubscriptionMapper.ToDto(subscription);
        }
    }

}

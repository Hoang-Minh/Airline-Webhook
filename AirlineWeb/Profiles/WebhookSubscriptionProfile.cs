using AirlineWeb.Dtos;
using AirlineWeb.Models;

namespace AirlineWeb.Profiles
{
    public class WebhookSubscriptionProfile : AutoMapper.Profile
    {
        public WebhookSubscriptionProfile()
        {
            CreateMap<WebhookSubscription, WebhookSubscriptionReadDto>();
            CreateMap<WebhookSubscriptionCreateDto, WebhookSubscription>();
        }
    }
}
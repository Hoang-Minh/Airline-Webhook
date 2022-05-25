using AirlineSendAgent.Dtos;

namespace AirlineSendAgent.Client
{
    public interface IWebhookClient
    {
        Task SendWebhookNotificationAsync(FlightDetailChangePayloadDto dto);
    }
}
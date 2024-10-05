namespace server_dthome.Repositories
{
    public interface ITwilioSMSRepository
    {
        Task SendSms(string toPhoneNumber, string message);
    }
}

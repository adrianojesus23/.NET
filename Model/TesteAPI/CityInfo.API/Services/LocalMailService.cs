namespace CityInfo.API.Services
{
    public class LocalMailService : ILocalMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettings:mailFromAddress"];
            _mailTo = configuration["mailSettings:mailToAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"{_mailFrom} - {_mailTo} - {nameof(LocalMailService)}");
            Console.WriteLine($"{subject}");
            Console.WriteLine($"{message}");
        }
    }
}

namespace Middleware_Services.Services
{
    public class EmailService : MessagingSenderService
    {
        public override void SendMessage(string message)
        {
            Console.WriteLine("I'm sending " + message + " as a mail.");
        }
    }
}

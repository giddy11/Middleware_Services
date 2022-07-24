using Microsoft.AspNetCore.Mvc;
using Middleware_Services.Services;
using Middleware_Services.TypesOfServices;

namespace Middleware_Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(MessagingSenderService messageService, ILogger<WeatherForecastController> logger, IServiceProvider serviceProvider)
        {
            _messageService = messageService ?? throw new ArgumentException(nameof(messageService));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentException(nameof(serviceProvider));
        }

        private readonly MessagingSenderService _messageService;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceProvider _serviceProvider;

        [HttpPost]
        public ActionResult SendMessage()
        {
            _messageService.SendMessage("Hello!");
            return Ok();
        }

        /// <summary>
        /// When executed the first time, we see the result in the console
        /// when executed again ,we see a new result
        /// finally when executed, we see same result showing the differences between the 3 types of services
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<WeatherForecast> GetMessage()
        {
            _logger.LogInformation($"Controller action executed on: {DateTime.Now.TimeOfDay}");
            Console.WriteLine("*************Request Start**************");
            var scopedService = _serviceProvider.GetService(typeof(ParentScoped));
            var scopedService1 = _serviceProvider.GetService(typeof(ParentScoped));

            var singletonService = _serviceProvider.GetService(typeof(ParentSingleton));
            var singletonService1 = _serviceProvider.GetService(typeof(ParentSingleton));

            var TransientService = _serviceProvider.GetService(typeof(ParentTransient));
            var TransientService1 = _serviceProvider.GetService(typeof(ParentTransient));
            var TransientService2 = _serviceProvider.GetService(typeof(ParentTransient));

            Console.WriteLine("********************Request End***************");
            return Ok();
        }
    }
}
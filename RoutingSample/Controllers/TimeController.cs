using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

namespace RoutingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeConverter _timeConvertor;
        public TimeController(ITimeConverter timeConverter)
        {
            _timeConvertor = timeConverter;
        }
        [HttpPost]
        [Route("[Action]/{toTimeZone}")]
        public IActionResult ConvertTime(Time time, string toTimeZone)
        {
            if (time == null || toTimeZone == null)
                return BadRequest("time and toTimeZone cannot be null");
            return Ok(_timeConvertor.ConvertTime(time, toTimeZone));
        }
        [HttpPost]
        [Route("[Action]/{fromTime}/{fromTimeZone}/{toTimeZone}")]
        public IActionResult ConvertTime(string fromTime, string fromTimeZone, string toTimeZone)
        {
            if (fromTime == null || fromTimeZone == null || toTimeZone == null)
                return BadRequest();
            Time time = new Time
            {
                LocalTime = fromTime,
                TimeZone = fromTimeZone
            };
            return Ok(_timeConvertor.ConvertTime(time, toTimeZone));
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult ConvertTimeQuery(string fromTime, string fromTimeZone, string toTimeZone)
        {
            if (fromTime == null || fromTimeZone == null || toTimeZone == null)
                return BadRequest();
            Time time = new Time
            {
                LocalTime = fromTime,
                TimeZone = fromTimeZone
            };
            return Ok(_timeConvertor.ConvertTime(time, toTimeZone));
        }
    }
}

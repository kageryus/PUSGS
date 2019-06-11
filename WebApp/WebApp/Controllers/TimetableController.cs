using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Timetable")]
    public class TimetableController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public TimetableController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            // _context = context;

        }

        [HttpGet]
        [Route("GetTimetables")]
        public IHttpActionResult GetTimetables()
        {
            return Ok(_unitOfWork.Timetable.GetAll());
        }

        [HttpGet]
        [Route("GetTimetable")]
        public IHttpActionResult GetTimetable()
        {
            var req = HttpContext.Current.Request;
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var lineId = Int32.Parse(req["lineId"].Trim());
            var day = req["day"].Trim();

            var Timetable = _unitOfWork.Timetable.Get(_unitOfWork.Line.Get(lineId).TimetableId);

            switch(day)
            {
                case "WorkDay":
                    return Ok(Timetable.WorkDay);
                    
                case "Saturday":
                    return Ok(Timetable.Saturday);
                    
                case "Sunday":
                    return Ok(Timetable.Sunday);
                    
            }

            return NotFound();

        }
        [HttpPut]
        [Route("UpdateTimetable")]
        public IHttpActionResult PutTimetable()
        {
            var req = HttpContext.Current.Request;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var lineId = Int32.Parse(req["lineId"].Trim());
            var workday = req["workday"].Trim();
            var saturday = req["saturday"].Trim();
            var sunday = req["sunday"].Trim();

            if (workday == null || saturday == null || sunday == null)
                return BadRequest();

            var Timetable = _unitOfWork.Timetable.Get(_unitOfWork.Line.Get(lineId).TimetableId);
            if (Timetable == null)
                return NotFound();

            Timetable.WorkDay = workday;
            Timetable.Saturday = saturday;
            Timetable.Sunday = sunday;

            _unitOfWork.Timetable.Update(Timetable);

            return Ok();
            
        }
    }
}

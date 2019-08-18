using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApp.Models;
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
        public IHttpActionResult GetTimetable(Line line, DayType day)
        {
            var allTimetables = _unitOfWork.Timetable.GetAll().ToList();

            var concreteTimetable = allTimetables.Where(x => x.LineId == line.Id && x.Day == day);
            if(concreteTimetable == null)
            {
                return NotFound();
            }
            foreach(var timetable in concreteTimetable)
            {
                timetable.Departures = timetable.Departures.OrderBy(x => x.Hour).ToList();
            }

            return Ok(concreteTimetable);

        }

        [HttpPost]
        [Route("AddTimetable")]
        public IHttpActionResult AddTimetable(Timetable timetable)
        {
            if (timetable == null)
                return BadRequest();

            Timetable newTimetable = new Timetable() { Day = timetable.Day, LineId = timetable.LineId };
            _unitOfWork.Timetable.Add(newTimetable);
            _unitOfWork.Complete();

            foreach(var x in timetable.Departures)
            {
                _unitOfWork.Departure.Add(new Departure() { Hour = x.Hour, Minutes = x.Minutes, TimeTableId = newTimetable.Id });
                _unitOfWork.Complete();

            }
            return Ok();
        }


        [HttpPut]
        [Route("UpdateTimetable")]
        public IHttpActionResult PutTimetable(Timetable timetable)
        {
            if (_unitOfWork.Timetable.Get(timetable.Id) != null)
            {
                _unitOfWork.Timetable.Update(timetable);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteTimetable")]
        public IHttpActionResult DeleteTimetable(int id)
        {
            var timetable = _unitOfWork.Timetable.Get(id);
            if (timetable == null)
            {
                return BadRequest();
            }

            foreach(var x in timetable.Departures)
            {
                _unitOfWork.Departure.Remove(x);                
            }

            _unitOfWork.Timetable.Remove(timetable);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}

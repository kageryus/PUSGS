using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Line")]
    public class LineController : ApiController
    {
        //private DbContext _context;
        private readonly IUnitOfWork _unitOfWork;


        public LineController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            // _context = context;

        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Line> GetLines()
        {
            return _unitOfWork.Line.GetAll();
        }

        [HttpGet]
        [Route("GetLine/{id}")]
        public IHttpActionResult GetLine(int id)
        {
            var line = _unitOfWork.Line.Get(id);
            return Ok(line);
        }

        [HttpPost]
        [Route("AddLine")]
        public IHttpActionResult AddLine(Line line)
        {
            if (line.Name == "" || line.Name == null)
            {
                return BadRequest("You have to fill line name!");
            }

            var lines = _unitOfWork.Line.GetAll().ToList();
            if (lines.Exists(x => x.Name == line.Name))
            {
                return BadRequest("Line with that name already exist");
            }

            if (line.Stations == null || line.Stations.Count < 2)
            {
                return BadRequest("Line must have at least two stations");
            }

            _unitOfWork.Line.Add(line);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateLine")]
        public IHttpActionResult UpdateLine(Line line)
        {
            _unitOfWork.Line.Update(line);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteLine")]
        public IHttpActionResult DeleteLine(int id)
        {
            var line = _unitOfWork.Line.Get(id);
            if (line != null)
            {
                _unitOfWork.Line.Remove(line);

                return Ok();
            }

            return BadRequest("That line don't exist");
        }

    }
}

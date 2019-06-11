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


    }
}

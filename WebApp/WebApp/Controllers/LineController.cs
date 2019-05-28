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
        private DbContext _context;
        IUnitOfWork _unitOfWork;

        public LineController(IUnitOfWork unitOfWork, DbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;

        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Line> GetLines()
        {
            return _unitOfWork.Line.GetAll();
        }


    }
}

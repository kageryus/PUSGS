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
    [RoutePrefix("api/Pricelist")]
    public class PricelistController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public PricelistController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        [Route("GetPrices")]
        public IHttpActionResult GetPrices()
        {
            
            var req = HttpContext.Current.Request;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var date = DateTime.Parse(req["date"].Trim());

            var pricelist = _unitOfWork.Pricelist.GetAll().Where(x => x.EndDate > date && x.StartDate < date).SelectMany(u => u.Stufs).ToList();
            var indexes = _unitOfWork.Index.GetAll().ToList();
            

            double[] ret = new double[26];

            ret[0] = pricelist.Where(t => t.Type == TicketType.time).Select(p => p.Price).FirstOrDefault();
            ret[1] = ret[0] * indexes.Where(t => t.CustomerType == CustomerType.penzioner).Select(k => k.Coefficient).FirstOrDefault();
            ret[2] = ret[0] * indexes.Where(t => t.CustomerType == CustomerType.student).Select(k => k.Coefficient).FirstOrDefault();

            ret[3] = pricelist.Where(t => t.Type == TicketType.day).Select(p => p.Price).FirstOrDefault();
            ret[4] = ret[3] * indexes.Where(t => t.CustomerType == CustomerType.penzioner).Select(k => k.Coefficient).FirstOrDefault();
            ret[5] = ret[3] * indexes.Where(t => t.CustomerType == CustomerType.student).Select(k => k.Coefficient).FirstOrDefault();

            ret[6] = pricelist.Where(t => t.Type == TicketType.month).Select(p => p.Price).FirstOrDefault();
            ret[7] = ret[6] * indexes.Where(t => t.CustomerType == CustomerType.penzioner).Select(k => k.Coefficient).FirstOrDefault();
            ret[8] = ret[6] * indexes.Where(t => t.CustomerType == CustomerType.student).Select(k => k.Coefficient).FirstOrDefault();

            ret[9] = pricelist.Where(t => t.Type == TicketType.year).Select(p => p.Price).FirstOrDefault();
            ret[10] = ret[9] * indexes.Where(t => t.CustomerType == CustomerType.penzioner).Select(k => k.Coefficient).FirstOrDefault();
            ret[11] = ret[9] * indexes.Where(t => t.CustomerType == CustomerType.student).Select(k => k.Coefficient).FirstOrDefault();

            //dodati prigradski



            return Ok(ret);
        }
    }
}

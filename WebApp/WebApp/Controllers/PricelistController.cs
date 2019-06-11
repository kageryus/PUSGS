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

            var pricelist = _unitOfWork.Pricelist.GetAll().Where(x => x.EndDate > date && x.StartDate < date);
            List<Stuf> stuf = new List<Stuf>();
            foreach( var x in pricelist)
            {
                stuf = x.Stufs;
            }



            
            

            return Ok();
        }
    }
}

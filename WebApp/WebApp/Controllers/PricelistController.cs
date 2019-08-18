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
        public IHttpActionResult GetPricelists()
        {
            return Ok(_unitOfWork.Pricelist.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetActualPricelist()
        {
            Pricelist pricelist = _unitOfWork.Pricelist.GetAll().ToList().FindLast(x => x.EndDate.Value.Date >= DateTime.Now.Date && x.StartDate.Value.Date <= DateTime.Now.Date);
            return Ok(pricelist);
        }

        [HttpPost]
        public IHttpActionResult AddPricelist(TicketPricelistHelper ticketPricelist)
        {
            if (ticketPricelist.Day < 1 || ticketPricelist.Month < 1 || ticketPricelist.Time < 1 || ticketPricelist.Year < 1)
                return BadRequest("Prices can't be less then 1");

            if (ticketPricelist.PriceList.StartDate.ToString() == "" || ticketPricelist.PriceList.EndDate.ToString() == "")
                return BadRequest("Dates can't be empty");

            if (ticketPricelist.PriceList.StartDate < DateTime.Now.Date)
                return BadRequest("Start date can't be in past");

            if (ticketPricelist.PriceList.StartDate > ticketPricelist.PriceList.EndDate)
                return BadRequest("End date can't be before start date");

            Pricelist pricelist = new Pricelist();
            pricelist.StartDate = ticketPricelist.PriceList.StartDate;
            pricelist.EndDate = ticketPricelist.PriceList.EndDate;
            _unitOfWork.Pricelist.Add(pricelist);
            _unitOfWork.Complete();

            var indexes = _unitOfWork.Index.GetAll().ToList();
            float normalIndex = indexes.Where(x => x.CustomerType == CustomerType.normal).Select(x => x.Coefficient).First();
            float studentIndex = indexes.Where(x => x.CustomerType == CustomerType.student).Select(x => x.Coefficient).First();
            float penzionerIndex = indexes.Where(x => x.CustomerType == CustomerType.penzioner).Select(x => x.Coefficient).First();

            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.day, CustomerType = CustomerType.normal, Price = ticketPricelist.Day * normalIndex, PriceListId= pricelist.Id});
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.month, CustomerType = CustomerType.normal, Price = ticketPricelist.Month * normalIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.year, CustomerType = CustomerType.normal, Price = ticketPricelist.Year * normalIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.time, CustomerType = CustomerType.normal, Price = ticketPricelist.Time * normalIndex, PriceListId = pricelist.Id });

            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.day, CustomerType = CustomerType.penzioner, Price = ticketPricelist.Day * penzionerIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.month, CustomerType = CustomerType.penzioner, Price = ticketPricelist.Month * penzionerIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.year, CustomerType = CustomerType.penzioner, Price = ticketPricelist.Year * penzionerIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.time, CustomerType = CustomerType.penzioner, Price = ticketPricelist.Time * penzionerIndex, PriceListId = pricelist.Id });

            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.day, CustomerType = CustomerType.student, Price = ticketPricelist.Day * studentIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.month, CustomerType = CustomerType.student, Price = ticketPricelist.Month * studentIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.year, CustomerType = CustomerType.student, Price = ticketPricelist.Year * studentIndex, PriceListId = pricelist.Id });
            _unitOfWork.TicketPrice.Add(new TicketPrice() { Type = TicketType.time, CustomerType = CustomerType.student, Price = ticketPricelist.Time * studentIndex, PriceListId = pricelist.Id });
            _unitOfWork.Complete();


            return Ok();
        }
    }
}

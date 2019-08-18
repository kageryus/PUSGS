using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using WebApp.Models;
using WebApp.Persistence.UnitOfWork;
using static WebApp.Controllers.AccountController;

namespace WebApp.Controllers
{
    [RoutePrefix("api/Ticket")]
    public class TicketController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetTicket")]
        public IHttpActionResult GetTicket(int id)
        {
            Ticket ticket = _unitOfWork.Ticket.Get(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        [Route("BuyTicket")]
        public IHttpActionResult BuyTicket()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            var userId = Int32.Parse(User.Identity.GetUserId());

            var req = HttpContext.Current.Request;
            double price = 0;
            var ticketType = req["type"].Trim();
            bool ch = false;
            TicketType ty = new TicketType();
            TimeSpan remTime = new TimeSpan();

            switch (ticketType)
            {
                case "TimeTicket":
                    ch = false;
                    ty = TicketType.time;
                    remTime = TimeSpan.FromMinutes(60);
                    price = _unitOfWork.Pricelist.GetAll().ToList().Where(x => x.StartDate < DateTime.Now && x.EndDate > x.EndDate).Select(x => x.TicketPrices).FirstOrDefault().Where(x=> x.Type == ty).Select(x=>x.Price).FirstOrDefault();
                    break;
                case "DailyTicket":
                    ch = false;
                    ty = TicketType.day;
                    price = _unitOfWork.Pricelist.GetAll().ToList().Where(x => x.StartDate < DateTime.Now && x.EndDate > x.EndDate).Select(x => x.TicketPrices).FirstOrDefault().Where(x => x.Type == ty).Select(x => x.Price).FirstOrDefault();
                    break;
                case "MonthlyTicket":
                    ch = false;
                    ty = TicketType.month;
                    price = _unitOfWork.Pricelist.GetAll().ToList().Where(x => x.StartDate < DateTime.Now && x.EndDate > x.EndDate).Select(x => x.TicketPrices).FirstOrDefault().Where(x => x.Type == ty).Select(x => x.Price).FirstOrDefault();
                    break;
                case "AnnualTicket":
                    ch = false;
                    ty = TicketType.year;
                    price = _unitOfWork.Pricelist.GetAll().ToList().Where(x => x.StartDate < DateTime.Now && x.EndDate > x.EndDate).Select(x => x.TicketPrices).FirstOrDefault().Where(x => x.Type == ty).Select(x => x.Price).FirstOrDefault();
                    break;
                default:
                    break;
            }


            Ticket ticket = new Ticket() { IsValid = true, BuyTime = DateTime.Now, Type = ty, UserId = userId, Price = price};
            if (ticketType == "TimeTicket")
                ticket.RemainingTime = remTime;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _unitOfWork.Ticket.Add(ticket);
            _unitOfWork.Complete();


            return Ok(ticket);
        }
    }
}

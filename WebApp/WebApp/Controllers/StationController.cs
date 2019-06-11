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
    [RoutePrefix("api/Station")]
    public class StationController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;


        public StationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        [HttpGet]
        [Route("GetStations")]
        public IHttpActionResult GetStations()
        {
            return Ok(_unitOfWork.Station.GetAll());
        }

        [HttpPut]
        [Route("UpdateStation")]
        public IHttpActionResult UpdateStations()
        {
            var req = HttpContext.Current.Request;
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = Int32.Parse(req["stationId"].Trim());
            var name = req["stationName"].Trim();
            var address = req["stationAddress"].Trim();
            var locationId = Int32.Parse((req["locationId"]).Trim());
            var longitude = (req["stationLongitude"].Trim());
            var latitude = (req["stationLongitude"].Trim());

            if (name == null || address == null || longitude == null || latitude == null)
                return BadRequest();

            

            var location = _unitOfWork.Location.Get(locationId);

            if (location.Latitude != double.Parse(latitude) || location.Longitude != double.Parse(longitude))
            {
                location.Latitude = double.Parse(latitude);
                location.Longitude = double.Parse(longitude);

                _unitOfWork.Location.Update(location);
            }

            var station = _unitOfWork.Station.Get(id);
            if (station == null)
                return NotFound();

            station.Name = name;
            station.Address = address;

            _unitOfWork.Station.Update(station);
            return Ok();
        }
    }
}

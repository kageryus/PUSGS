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
            var stations = _unitOfWork.Station.GetAll();
            
            return Ok(stations);
        }

        [HttpPut]
        [Route("UpdateStation")]
        public IHttpActionResult UpdateStations(Station station)
        {
            //var req = HttpContext.Current.Request;
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            //var id = Int32.Parse(req["stationId"].Trim());
            //var name = req["stationName"].Trim();
            //var address = req["stationAddress"].Trim();
            //var locationId = Int32.Parse((req["locationId"]).Trim());
            //var longitude = (req["stationLongitude"].Trim());
            //var latitude = (req["stationLongitude"].Trim());

            //if (name == null || address == null || longitude == null || latitude == null)
            //    return BadRequest();

            

            //var location = _unitOfWork.Location.Get(locationId);

            //if (location.Latitude != double.Parse(latitude) || location.Longitude != double.Parse(longitude))
            //{
            //    location.Latitude = double.Parse(latitude);
            //    location.Longitude = double.Parse(longitude);

            //    _unitOfWork.Location.Update(location);
            //}

            var station1 = _unitOfWork.Station.Get(station.Id);
            if (station1 == null)
                return NotFound();

            //station1.Name = station.Name;
            //station1.Address = station.Address;
            //station1.Latitude = station.Latitude;
            //station1.Longitude = station.Longitude;
            

            _unitOfWork.Station.Update(station);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("AddStation")]
        public IHttpActionResult AddStation(Station station)
        {
            
            
            //double lon, lat = new double();

            //if (!Double.TryParse(station.Latitude, out lat))
            //{
            //    return BadRequest("Please check latitude");
            //}

            //if (!Double.TryParse(station.longitude.Trim(), out lon))
            //{
            //    return BadRequest("Please check longitude");
            //}

        
            _unitOfWork.Station.Add(station);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStationToLine(int id, Station station)
        {
            //var req = HttpContext.Current.Request;
            //var temp = req["id"];
            //var temp1 = req["station"];
            //if (req["id"] == "undefined" || req["id"] == null || req["id"] == "")
            //{
            //    return BadRequest("Please select line");
            //};

            //if (req["station"] == "undefined" || req["station"] == null || req["station"] == "")
            //{
            //    return BadRequest("Please select line");
            //};

            Line line = _unitOfWork.Line.Get(id);
            //if (line.Version.ToString() != req["version"].Trim())
            //{
            //    return BadRequest("Line changed by sombody else, please reload to get new version");
            //}
            
            if (line.Stations.Contains(_unitOfWork.Station.GetAll().Where((u) => u.Name.ToString() == station.Name).FirstOrDefault()))
            {
                return BadRequest("There is allredy station " + station.Name + "in line " + line.Name);
            }

            //line.Version += 0.1;

            line.Stations.Add(_unitOfWork.Station.GetAll().Where((u) => u.Name.ToString() == station.Name).FirstOrDefault());

            //try
            //{
                _unitOfWork.Line.Update(line);
                _unitOfWork.Complete();

            //}
            //catch (ChangeConflictException)
            //{

            //    return BadRequest("You have old version of files. Please reload page.");
            //}
            //catch (Exception)
            //{
            //    return BadRequest("Error.Please reload and try again.");
            //}


            return Ok("Station " + station.Name + " added");            
        }
        [HttpPost]
        public IHttpActionResult DeleteStation(int id)
        {
            


            var station = _unitOfWork.Station.Get(id);

            //if (station.Version.ToString() != req["version"].Trim())
            //{
            //    return BadRequest("station changed by somebody else, please reload to get new version");
            //}
            if (station == null)
            {
                return BadRequest("There is no station with entered number");
            }



            _unitOfWork.Station.Remove(station);            
            _unitOfWork.Complete();

            return Ok("Station deleted");
        }

    }        
}

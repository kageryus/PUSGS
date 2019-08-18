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
            var stats = new List<StationModel>();
            foreach(var station in stations)
            {
                var location = _unitOfWork.Location.Get(station.LocationId);                
                stats.Add(new StationModel {id = station.Id, address = station.Address, latitude = location.Latitude, longitude = location.Longitude, name = station.Name });
            }

            return Json(stats);
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
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("AddStation")]
        public IHttpActionResult AddStation(AddStationModel station)
        {
            var req = HttpContext.Current.Request;

            if(!ModelState.IsValid)
            {
                var mssg = ModelState.Values.Select((u) => u.Errors.Select((i) => i.ErrorMessage).FirstOrDefault()).FirstOrDefault();
                return BadRequest(mssg);
            }

            double lon, lat = new double();

            if (!Double.TryParse(station.latitude, out lat))
            {
                return BadRequest("Please check latitude");
            }

            if (!Double.TryParse(station.longitude.Trim(), out lon))
            {
                return BadRequest("Please check longitude");
            }

            Station newStation = new Station() { Name = station.name.Trim(), Location = new Location() { Latitude = lat, Longitude = lon }, Address = station.address };

            _unitOfWork.Station.Add(newStation);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStationToLine()
        {
            var req = HttpContext.Current.Request;
            var temp = req["id"];
            var temp1 = req["station"];
            if (req["id"] == "undefined" || req["id"] == null || req["id"] == "")
            {
                return BadRequest("Please select line");
            };

            if (req["station"] == "undefined" || req["station"] == null || req["station"] == "")
            {
                return BadRequest("Please select line");
            };

            Line line = _unitOfWork.Line.GetAll().Where((u) => u.Name == req["id"].Trim()).FirstOrDefault();
            //if (line.Version.ToString() != req["version"].Trim())
            //{
            //    return BadRequest("Line changed by sombody else, please reload to get new version");
            //}
            
            if (line.Stations.Contains(_unitOfWork.Station.GetAll().Where((u) => u.Name.ToString() == req["station"].Trim()).FirstOrDefault()))
            {
                return BadRequest("There is allredy station " + req["station"] + "in line " + req["id"]);
            }

            //line.Version += 0.1;

            line.Stations.Add(_unitOfWork.Station.GetAll().Where((u) => u.Name.ToString() == req["station"].Trim()).FirstOrDefault());

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


            return Ok("Station " + req["station"] + " added");            
        }
        [HttpPost]
        public IHttpActionResult DeleteStation()
        {
            var req = HttpContext.Current.Request;
            if (req["id"] == "undefined" || req["id"] == "" || req["id"] == null)
            {
                return BadRequest("Please enter station number");
            }
            int id;
            if (!Int32.TryParse(req["id"], out id))
            {
                return BadRequest("Wrong enter, must be number");
            }


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
            _unitOfWork.Location.Remove(_unitOfWork.Location.Get(station.LocationId));
            _unitOfWork.Complete();

            return Ok("Station deleted");
        }

    }        
}

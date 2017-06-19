using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyCarClassifieds.db;
using MyCarClassifieds.Models;
using System.Data.Entity;

namespace MyCarClassifieds.Controllers
{
    public class VehiclesController : ApiController
    {
        private AppDbContext _context;
        public VehiclesController()
        {
            _context = new AppDbContext();
        }

        [Route("api/vehicles/{id?}")]
        [HttpGet]
        public IHttpActionResult GetVehicle(int id)
        {
            var newVehicle = _context.Vehicles.Include(f => f.Features).Include(m=>m.Model).Include(n=>n.Model.Make)
                .FirstOrDefault<Vehicle>(v => v.Id == id);

            if (newVehicle == null)
            {
                return NotFound();
            }

            return Ok(newVehicle);
        }

        [Route("/api/vehicles")]
        [HttpPost]
        public IHttpActionResult NewVehicle([FromBody]SaveVehicleDTO vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicle newVehicle = new Vehicle();
            newVehicle.ModelId = vehicle.ModelId;
            newVehicle.ContactName = vehicle.ContactName;
            newVehicle.ContactPhone = vehicle.ContactPhone;
            newVehicle.ContactEmail = vehicle.ContactEmail;
            newVehicle.IsRegistered = vehicle.IsRegistered;
            newVehicle.LastUpdate = DateTime.Now;

            foreach (var featureId in vehicle.Features)
            {
                newVehicle.Features.Add(new VehicleFeature { FeatureId = featureId, VehicleId = newVehicle.Id });
            }

            _context.Vehicles.Add(newVehicle);
            _context.SaveChanges();

            return Ok(newVehicle);
        }

        [Route("/api/vehicles/{id?}")]
        [HttpPut]
        public IHttpActionResult EditVehicle(int id, [FromBody]SaveVehicleDTO vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicle newVehicle = _context.Vehicles.Include(f => f.Features).First<Vehicle>(v => v.Id == id);

            if (newVehicle == null)
            {
                return NotFound();
            }

            newVehicle.ModelId = vehicle.ModelId;
            newVehicle.ContactName = vehicle.ContactName;
            newVehicle.ContactPhone = vehicle.ContactPhone;
            newVehicle.ContactEmail = vehicle.ContactEmail;
            newVehicle.IsRegistered = vehicle.IsRegistered;
            newVehicle.LastUpdate = DateTime.Now;

            var removed = new List<VehicleFeature>();

            foreach (var feature in newVehicle.Features)
            {
                if (vehicle.Features.FirstOrDefault(f => f == feature.FeatureId) == 0)
                {
                    removed.Add(feature);
                }
            }

            foreach (var remove in removed)
            {
                newVehicle.Features.Remove(remove);
            }

            foreach (var featureId in vehicle.Features)
            {
                if (newVehicle.Features.FirstOrDefault(f => f.FeatureId == featureId) == null)
                {
                    newVehicle.Features.Add(new VehicleFeature { FeatureId = featureId, VehicleId = newVehicle.Id });
                }
            }

            _context.SaveChanges();

            return Ok(newVehicle);
        }

        [Route("/api/vehicles/{id?}")]
        [HttpDelete]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var newVehicle = _context.Vehicles.Include(f => f.Features).FirstOrDefault<Vehicle>(v => v.Id == id);
            if (newVehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(newVehicle);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
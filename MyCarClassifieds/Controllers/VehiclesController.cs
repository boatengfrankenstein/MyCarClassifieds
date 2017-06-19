using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCarClassifieds.db;
using MyCarClassifieds.Models;

namespace MyCarClassifieds.Controllers
{
    public class VehiclesController : Controller
    {
        private AppDbContext _context;
        public VehiclesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/vehicles/{id?}")]
        public IActionResult GetVehicle(int id)
        {
            var newVehicle = _context.Vehicles.Include(f => f.Features).FirstOrDefault<Vehicle>(v => v.Id == id);

            if (newVehicle == null)
            {
                return NotFound();
            }

            return Ok(newVehicle);
        }

        [HttpPost("/api/vehicles")]
        public IActionResult NewVehicle([FromBody]VehicleDTO vehicle)
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

        [HttpPut("/api/vehicles/{id?}")]
        public IActionResult EditVehicle(int id, [FromBody]VehicleDTO vehicle)
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

        [HttpDelete("/api/vehicles/{id?}")]
        public IActionResult DeleteVehicle(int id)
        {
            var newVehicle = _context.Vehicles.Include(f => f.Features).FirstOrDefault<Vehicle>(v => v.Id == id);
            if (newVehicle == null)
            {
                return NotFound();
            }
            _context.Remove(newVehicle);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
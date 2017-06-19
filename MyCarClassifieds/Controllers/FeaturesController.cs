using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCarClassifieds.db;
using MyCarClassifieds.Models;

namespace MyCarClassifieds.Controllers
{
    public class FeaturesController : Controller
    {
        private AppDbContext _context;
        public FeaturesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/features")]
        public IEnumerable<Feature> Makes()
        {
            return _context.Features;
        }
    }
}
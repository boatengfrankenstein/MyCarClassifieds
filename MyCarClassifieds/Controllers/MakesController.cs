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
    public class MakesController : Controller
    {
        private AppDbContext _context;
        public MakesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/makes")]
        public IEnumerable<Make> Makes()
        {
            return _context.Makes.Include(m => m.Models).ToList<Make>();
        }
    }
}

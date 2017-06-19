using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyCarClassifieds.db;
using MyCarClassifieds.Models;

namespace MyCarClassifieds.Controllers
{
    public class MakesController : ApiController
    {
        private AppDbContext _context;
        public MakesController(AppDbContext context)
        {
            _context = new AppDbContext();
        }

        [Route("api/features")]
        [HttpGet]
        public IEnumerable<Make> Makes()
        {
            return _context.Makes.Include("Models").ToList<Make>();
        }
    }
}

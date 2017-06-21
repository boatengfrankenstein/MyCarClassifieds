using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyCarClassifieds.DataHelpers;
using MyCarClassifieds.Models;

namespace MyCarClassifieds.Controllers
{
    public class MakesController : ApiController
    {
        private AppDbContext _context;
        public MakesController()
        {
            _context = new AppDbContext();
        }

        [Route("api/makes")]
        [HttpGet]
        public IEnumerable<Make> Makes()
        {
            return _context.Makes.Include("Models").ToList<Make>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MyCarClassifieds.DataHelpers;
using MyCarClassifieds.Models;

namespace MyCarClassifieds.Controllers
{
    public class FeaturesController : ApiController
    {
        private AppDbContext _context;
        public FeaturesController()
        {
            _context = new AppDbContext();
        }

        [Route("api/features")]
        [HttpGet]
        public IEnumerable<Feature> Get()
        {
            return _context.Features;
        }
    }
}
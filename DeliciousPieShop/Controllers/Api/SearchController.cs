using DeliciousPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliciousPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public SearchController(IPieRepository pieRepository)
        {
            PieRepository = pieRepository;
        }

        public IPieRepository PieRepository { get; }

        [HttpGet]
        public IActionResult GetAll()
        {

            IEnumerable<Pie> allPies = PieRepository.AllPies;
            return base.Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pies = PieRepository.GetPieById(id);
            if(pies == null)
            {
                return NotFound();
            }
            return Ok(pies);
        }


        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            List<Pie> pies = new List<Pie>();
            if(!String.IsNullOrEmpty(searchQuery))
            {
                pies.AddRange(PieRepository.SearchPies(searchQuery));
            }
            return new JsonResult(pies);
        }
    }
}

using FloweryGladeAPI.Models;
using FloweryGladeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloweryGladeAPI.Controllers
{
    [Route("api/floweryGlade/{flowerShopID}/flower")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerService _flowerService;

        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute]int flowerShopID, CreateFlowerDto dto)
        {
            var newFlowerID = _flowerService.Create(flowerShopID, dto);
            return Created($"api/floweryGlade/{flowerShopID}/flower/{newFlowerID}",null);
        }
    }
}

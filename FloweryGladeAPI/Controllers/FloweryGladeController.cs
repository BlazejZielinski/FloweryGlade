using AutoMapper;
using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Models;
using FloweryGladeAPI.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FloweryGladeAPI.Controllers
{
    [Route("api/floweryGlade")]
    public class FloweryGladeController : ControllerBase
    {
        private readonly IFlowerShopService _flowerShopService;

        public FloweryGladeController(IFlowerShopService flowerShopService)
        {
           _flowerShopService = flowerShopService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlowerShopDTO>> GetAll()
        {

            var flowerShopDtos = _flowerShopService.GetAll();
            return Ok(flowerShopDtos);


        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FlowerShopDTO>> GetByID([FromRoute]int id)
        {
            var flowerShopByID = _flowerShopService.GetByID(id);
            if(flowerShopByID is null)
            {
                return NotFound("Nie ma takiego zasobu");
            }
            return Ok(flowerShopByID);
        }

        [HttpPost]
        public ActionResult CreateFlowerShop([FromBody] CreateFlowerShopDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _flowerShopService.Create(dto);

            return Created($"api/floweryGlade/{id}", null);
        }
    }
}

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

        // GetAll shops
        [HttpGet]
        public ActionResult<IEnumerable<FlowerShopDTO>> GetAll()
        {

            var flowerShopDtos = _flowerShopService.GetAll();
            return Ok(flowerShopDtos);


        }

        // GetByID shop
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FlowerShopDTO>> GetByID([FromRoute]int id)
        {
            var flowerShopByID = _flowerShopService.GetByID(id);
            
            return Ok(flowerShopByID);
        }

        // creating new shop
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

        // deleting shop by ID
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _flowerShopService.Delete(id);

            
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateFlowerShopDto updateDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _flowerShopService.Update(id, updateDto);
            return Ok("Resource updated");

        }
    }
}

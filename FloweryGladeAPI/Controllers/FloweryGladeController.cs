using AutoMapper;
using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FloweryGladeAPI.Controllers
{
    [Route("api/floweryGlade")]
    public class FloweryGladeController : ControllerBase
    {
        private readonly FlowerShopDbContext _dbContext;
        private readonly IMapper _mapper;

        // działa
        //public FloweryGladeController(FlowerShopDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public FloweryGladeController(FlowerShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlowerShopDTO>> GetAll()
        {
            var flowerShops = _dbContext
                .FlowerShops
                .Include(f=>f.Address)      // added table named "Address"
                .Include(f=>f.Flower)       // added table named "Flower"
                //.Include(i=>i.Users)       // added table named "Users"
                //.Include(i=>i.Clients)       // added table named "Clients"
                .ToList();

            // prawidłowe, przy użyciu automapera(
            // AutoMapper.Extensions.Microsoft.DependencyInjection
            // ) 
            // z menegera paczek nuget
            //var flowersDtos = _mapper
            //    .Map<IEnumerable<FlowerShopDTO>>(flowerShops);    // w Map()
            //    //.Map<IEnumerable<FlowerShopDTO>>(flowerShops);    // w Map()

            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var flowersDtos = _mapper
                .Map<List<FlowerShopDTO>>(flowerShops);    // w Map()
            //.Map<IEnumerable<FlowerShopDTO>>(flowerShops);    // w Map()

            // Map created by Mapster package
            //var flowersDtos = flowerShops.Adapt<IEnumerable<FlowerShopDTO>>();


            // podajemy typ generyczny, na który
            // chcemy zmapować, natomiast
            // w nawiasach podajemy źródło

            //return Ok(flowerShops);
            return Ok(flowersDtos);

            // NIEWŁAŚCIWE, PONIEWAŻ PRZY KAŻDYM MAPOWANIU,
            // TRZEBA BY BYŁO MAPOWAĆ OSOBNE WARTOŚCI
            //var flowersDtos = flowershops.Select(f => new FlowerShopDTO()
            //{
            //    Name = f.Name,
            //    PhoneNo = f.PhoneNo,
            //    City = f.Address.City,
            //    ZipCode = f.Address.ZipCode,
            //    Street = f.Address.Street,
            //    HouseNumber = f.Address.HouseNo,

            //});


        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<FlowerShopDTO>> GetByID([FromRoute]int id)
        {
            var flowerShopsByID = _dbContext
                .FlowerShops
                .Include(i => i.Address)      // added table named "Address"
                .Include(i => i.Flower)       // added table named "Flower"
                .FirstOrDefault(f => f.FlowerShopID == id);
            if(flowerShopsByID == null)
            {
                return NotFound("Wymieniony zasób NIE ISTNIEJE!!!");
            }

            var flowershopByIDDTO = _mapper.Map<FlowerShopDTO>(flowerShopsByID);
            //var flowershopByIDDTO = flowerShopsByID.Adapt<FlowerShopDTO>();
            return Ok(flowershopByIDDTO);
        }

        [HttpPost]
        public ActionResult CreateFlowerShop([FromBody] CreateFlowerShopDto dto)
        {
            var flowerShop = _mapper.Map<FlowerShop>(dto);
            _dbContext.FlowerShops.Add(flowerShop);
            _dbContext.SaveChanges();

            return Created($"api/floweryGlade/{flowerShop.FlowerShopID}", null);
        }
    }
}

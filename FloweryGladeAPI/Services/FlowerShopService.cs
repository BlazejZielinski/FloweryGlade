using AutoMapper;
using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Exceptions;
using FloweryGladeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FloweryGladeAPI.Services
{
    public interface IFlowerShopService
    {
        int Create(CreateFlowerShopDto dto);
        IEnumerable<FlowerShopDTO> GetAll();
        FlowerShopDTO GetByID(int id);
        void Delete(int id);
        void Update(int id, UpdateFlowerShopDto updateDto);
    }

    public class FlowerShopService : IFlowerShopService
    {
        private readonly FlowerShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<FlowerShopService> _logger;

        public FlowerShopService(FlowerShopDbContext dbContext, IMapper mapper, 
            ILogger<FlowerShopService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public FlowerShopDTO GetByID(int id)
        {
            var flowerShopsByID = _dbContext
                .FlowerShops
                .Include(i => i.Address)      // added table named "Address"
                .Include(i => i.Flower)       // added table named "Flower"
                .FirstOrDefault(f => f.FlowerShopID == id);
            if (flowerShopsByID == null)
            {
                throw new NotFoundException($"Resource with id: {id} not found");
            }

            var result = _mapper.Map<FlowerShopDTO>(flowerShopsByID);
            return result;
        }

        public void Delete(int id)
        {
            _logger.LogError($"FlowerShop with id: {id} DELETE action invoked");
            //_logger.LogWarning($"FlowerShop with id: {id} DELETE action invoked");
            var flowerShop = _dbContext
                .FlowerShops
                .FirstOrDefault(f => f.FlowerShopID == id);

            if(flowerShop == null) {
                throw new NotFoundException($"Resource with id: {id} not found"); 
            }
            _dbContext.FlowerShops.Remove(flowerShop);
            _dbContext.SaveChanges();


            
        }

        public void Update(int id, UpdateFlowerShopDto updateDto)
        {
            var flowerShopsByID = _dbContext
                .FlowerShops
                .Include(i => i.Address)      // added table named "Address"
                .Include(i => i.Flower)       // added table named "Flower"
                .FirstOrDefault(f => f.FlowerShopID == id);

            if (flowerShopsByID == null)
            {
                throw new NotFoundException($"Resource with id: {id} not found");
            }

            flowerShopsByID.Name = updateDto.Name;
            flowerShopsByID.Address.Street = updateDto.Street;
            flowerShopsByID.Address.HouseNo = updateDto.HouseNumber;

            _dbContext.SaveChanges();

            

        }

        public IEnumerable<FlowerShopDTO> GetAll()
        {
            var flowerShops = _dbContext
               .FlowerShops
               .Include(f => f.Address)      // added table named "Address"
               .Include(f => f.Flower)       // added table named "Flower"

               .ToList();


            var flowersDtos = _mapper
                .Map<List<FlowerShopDTO>>(flowerShops);  
            return flowersDtos;

        }

        public int Create(CreateFlowerShopDto dto)
        {
            var flowerShop = _mapper.Map<FlowerShop>(dto);
            _dbContext.FlowerShops.Add(flowerShop);
            _dbContext.SaveChanges();

            return flowerShop.FlowerShopID;
        }
    }
}

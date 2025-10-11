using AutoMapper;
using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FloweryGladeAPI.Services
{
    public interface IFlowerShopService
    {
        int Create(CreateFlowerShopDto dto);
        IEnumerable<FlowerShopDTO> GetAll();
        FlowerShopDTO GetByID(int id);
        bool Delete(int id);
        bool Update(int id, UpdateFlowerShopDto updateDto);
    }

    public class FlowerShopService : IFlowerShopService
    {
        private readonly FlowerShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public FlowerShopService(FlowerShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
                return null;
            }

            var result = _mapper.Map<FlowerShopDTO>(flowerShopsByID);
            return result;
        }

        public bool Delete(int id)
        {
            var flowerShop = _dbContext
                .FlowerShops
                .FirstOrDefault(f => f.FlowerShopID == id);

            if(flowerShop == null) {  return false; }
            _dbContext.FlowerShops.Remove(flowerShop);
            _dbContext.SaveChanges();


            return true;
        }

        public bool Update(int id, UpdateFlowerShopDto updateDto)
        {
            var flowerShopsByID = _dbContext
                .FlowerShops
                .Include(i => i.Address)      // added table named "Address"
                .Include(i => i.Flower)       // added table named "Flower"
                .FirstOrDefault(f => f.FlowerShopID == id);

            if (flowerShopsByID == null)
            {
                return false;
            }

            flowerShopsByID.Name = updateDto.Name;
            flowerShopsByID.Address.Street = updateDto.Street;
            flowerShopsByID.Address.HouseNo = updateDto.HouseNumber;

            _dbContext.SaveChanges();

            return true; 

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

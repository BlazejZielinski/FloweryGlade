using AutoMapper;
using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Exceptions;
using FloweryGladeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FloweryGladeAPI.Services
{
    public interface IFlowerService
    {
        int Create(int flowerShopID, CreateFlowerDto dto);
    }
    public class FlowerService : IFlowerService
    {
        private readonly FlowerShopDbContext _context;
        private readonly IMapper _mapper;

        public FlowerService(FlowerShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int flowerShopID, [FromBody]CreateFlowerDto dto)
        {
            var flowerShop = 
                _context.FlowerShops.FirstOrDefault(f=>f.FlowerShopID == flowerShopID);
            if (flowerShop == null)
                throw new NotFoundException($"FlowerShop with id: {flowerShopID} " +
                    $"does not exists");
            var flowerEntity = _mapper.Map<Flowers>(dto);

            flowerEntity.FlowerShopID = flowerShopID;

            _context.Flowers.Add(flowerEntity);
            _context.SaveChanges();

            return flowerEntity.ID;
        }
    }
}

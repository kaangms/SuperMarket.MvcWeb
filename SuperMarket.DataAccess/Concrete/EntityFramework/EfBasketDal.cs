using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.DataAccess.Concrete.EntityFramework.Contexts;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;


namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket>, IBasketDal
    {
        private SuperMarketDbContext _context;
        public EfBasketDal(DbContext context, SuperMarketDbContext context1) : base(context)
        {
            _context = context1;
        }


        public List<BasketDto> GetListBasketDto(int userId)
        {
           
                var result = from contextBasket in _context.Baskets
                             join contextBasketDetail in _context.BasketDetails on contextBasket.Id equals contextBasketDetail
                                 .BasketId into bd
                             from contextBasketDetail in bd.DefaultIfEmpty()
                             join contextProduct in _context.Products on contextBasketDetail.ProductId equals contextProduct.Id into p
                             from contextProduct in p.DefaultIfEmpty()

                             where contextBasket.UserId == userId
                             select new BasketDto()
                             {
                                 Basket = contextBasket,
                                 BasketDetail = contextBasketDetail,
                                 Product = contextProduct
                             };
                return result.ToList().FindAll(r => r.Basket.BasketStatus == true);
            }
    }
}
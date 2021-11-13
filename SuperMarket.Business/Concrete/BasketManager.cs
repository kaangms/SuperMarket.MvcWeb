using Core.Utilities.Results;
using SuperMarket.Business.Abstract;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;
using SuperMarket.Business.Constants;

namespace SuperMarket.Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDetailService _basketDetailService;
        private readonly IUnitOfWork _unitOfWork;

        public BasketManager(IUnitOfWork unitOfWork, IBasketDetailService basketDetailService)
        {
            _unitOfWork = unitOfWork;
            _basketDetailService = basketDetailService;
        }

        public IDataResult<Basket> GetBasket(int userId)
        {
            var basketList = _unitOfWork.BasketDal.GetList(b => b.UserId == userId);
            var basket = basketList.FirstOrDefault(b => b.BasketStatus == true);
            if (basket != null)
            {
                return new SuccessDataResult<Basket>(basket);
            }
            return new SuccessDataResult<Basket>();
        }

        public IResult AddBasket(int userId, int productId)
        {
            var basket = CheckBasket(userId).Data;
            if (CheckProductStockAmount(productId)) return new ErrorResult(Messages.ErrorMessageForNullStock);
           

           ;

            var basketDetail = _basketDetailService.AddToBasketDetail(productId, basket.Id).Data;
            UpdateBasket(basket, basketDetail);
            return new SuccessResult(Messages.SuccessAddedToBasket);
        }

        private bool CheckProductStockAmount(int productId)
        {
            return _unitOfWork.ProductDal.Get(p => p.Id == productId).StockAmount < 0;
        }

        public IDataResult<Basket> CheckBasket(int userId)
        {
            var result = GetBasket(userId).Data;
            if (result == null) result = AddBasketToUser(userId).Data;
            return new SuccessDataResult<Basket>(result);
        }

        public IDataResult<Basket> AddBasketToUser(int userId)
        {
            var basket = new Basket
            {
                UserId = userId,
                BasketStatus = true
            };
            var result = _unitOfWork.BasketDal.Add(basket);
            _unitOfWork.SaveChanges();
            return new SuccessDataResult<Basket>(result.Entity);
        }

        public IResult UpdateBasket(Basket basket, List<BasketDetail> basketDetail)
        {
            basket.ProductCount = basketDetail.Sum(bd => bd.Amount);
            basket.TotalPrice = basketDetail.Sum(bd => bd.TotalPrice);
            UpdateBasket(basket);
            _unitOfWork.SaveChanges();
            return new SuccessResult();
        }

        public IResult UpdateBasket(Basket basket)
        {
            _unitOfWork.BasketDal.Update(basket);
            return new SuccessResult();
        }

        public IDataResult<List<BasketDto>> GetListBasketDto(int userId)
        {
            var result = _unitOfWork.BasketDal.GetListBasketDto(userId);

            return new SuccessDataResult<List<BasketDto>>(result);
        }
    }
}
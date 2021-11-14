using System;
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

        public IDataResult<Basket> GetWaitingBasket(int userId)
        {
            var basket = _unitOfWork.BasketDal.Get(b => b.BasketStatus && b.UserId==userId);
            if (basket != null)
            {
                return new SuccessDataResult<Basket>(basket);
            }

            return new ErrorDataResult<Basket>();
        }
        public  IDataResult<List<BasketDto>> AddAndReturnBasketResult(int userId, int productId)
        {
          var message =  AddBasket(userId, productId).Message;
            return  new SuccessDataResult<List<BasketDto>>(GetListBasketDto(userId).Data,message)    ;
        }
        private IResult AddBasket(int userId, int productId)
        {
            var basket = CheckBasket(userId).Data;
            if (CheckProductStockAmount(productId)) return new ErrorResult(Messages.ErrorMessageForNullStock);
            var basketDetail = _basketDetailService.AddToBasketDetail(productId, basket.Id).Data;
            UpdateBasket(basket, basketDetail);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.SuccessAddedToBasket);
        }


        private bool CheckProductStockAmount(int productId)
        {
            return _unitOfWork.ProductDal.Get(p => p.Id == productId).StockAmount <= 0;
        }

        private IDataResult<Basket> CheckBasket(int userId)
        {
            var result = GetWaitingBasket(userId);
            if (!result.Success)AddBasketToUser(userId);
            result = GetWaitingBasket(userId);
            return result;
        }

        private IDataResult<Basket> AddBasketToUser(int userId)
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

        public IResult RemoveProductFromBasket(int basketDetailId)
        {
            var basketDetail = _unitOfWork.BasketDetailDal.Get(bd => bd.Id == basketDetailId);
            _unitOfWork.BasketDetailDal.Remove(basketDetail);
            UpdateBasketForRemovedBasketDetail(basketDetail);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.RemoveProductFromBasket);
        }

        private IResult UpdateBasketForRemovedBasketDetail(BasketDetail basketDetail)
        {
            var basket = _unitOfWork.BasketDal.Get(b => b.Id == basketDetail.BasketId);
            basket.ProductCount -= basketDetail.Amount;
            basket.TotalPrice -= basketDetail.TotalPrice;
            _unitOfWork.BasketDal.Update(basket);
            return new SuccessResult();

        }
    }
}
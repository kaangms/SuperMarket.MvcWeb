using Core.Utilities.Results;
using SuperMarket.Business.Abstract;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket.Business.Concrete
{
    public class BasketDetailManager : IBasketDetailService
    {
        private readonly IProductService _productService;

        private readonly IUnitOfWork _unitOfWork;

        public BasketDetailManager(IUnitOfWork unitOfWork, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public IDataResult<List<BasketDetail>> GetBasketDetailList(int basketId)
        {
            var result = _unitOfWork.BasketDetailDal.GetList(bd => bd.BasketId == basketId);

            return new SuccessDataResult<List<BasketDetail>>(result.ToList());
        }

        public IDataResult<BasketDetail> GetBasket(int basketDetailId)
        {
            var result = _unitOfWork.BasketDetailDal.Get(bd => bd.Id == basketDetailId);

            return new SuccessDataResult<BasketDetail>(result);
        }

        public IDataResult<BasketDetail> GetBasket(int productId, int basketId)
        {
            var basketDetailCheck = GetBasketDetailList(basketId).Data;
            var basketDetail = basketDetailCheck.FirstOrDefault(bd => bd.ProductId == productId);
            return new SuccessDataResult<BasketDetail>(basketDetail);
        }

        public IDataResult<List<BasketDetail>> AddToBasketDetail(int productId, int basketId)
        {
            var basketDetailCheckProduct = CheckBasketDetailToProduct(productId, basketId).Data;
            if (basketDetailCheckProduct.FirstOrDefault(bd => bd.ProductId == productId) != null)
                return new SuccessDataResult<List<BasketDetail>>(basketDetailCheckProduct);

            basketDetailCheckProduct = AddProductThenUpdateBasketDetail(productId, basketId).Data;
            return new SuccessDataResult<List<BasketDetail>>(basketDetailCheckProduct);
        }

        public IDataResult<List<BasketDetail>> AddProductThenUpdateBasketDetail(int productId, int basketId)
        {
            var product = _productService.GetById(productId).Data;
            var basketDetail = new BasketDetail
            {
                BasketId = basketId,
                ProductId = product.Id,
                Amount = 1,
                Price = product.UnitPrice,
                TotalPrice = product.UnitPrice
            };
            _unitOfWork.BasketDetailDal.Add(basketDetail);
            _unitOfWork.SaveChanges();
            var basketDetailList = GetBasketDetailList(basketId).Data;
            return new SuccessDataResult<List<BasketDetail>>(basketDetailList);
        }

        public IDataResult<List<BasketDetail>> CheckBasketDetailToProduct(int productId, int basketId)
        {
            var basketDetailCheckProduct = GetBasket(productId, basketId).Data;
            if (basketDetailCheckProduct != null)
            {
                basketDetailCheckProduct.Amount++;
                basketDetailCheckProduct.TotalPrice = basketDetailCheckProduct.Amount * basketDetailCheckProduct.Price;
                _unitOfWork.BasketDetailDal.Update(basketDetailCheckProduct);
                _unitOfWork.SaveChanges();
            }

            var basketDetailList = GetBasketDetailList(basketId).Data;
            return new SuccessDataResult<List<BasketDetail>>(basketDetailList);
        }

        public IResult RemoveFromBasketDetail(int basketDetailId)
        {
            var basketDetail = GetBasket(basketDetailId).Data;
            _unitOfWork.BasketDetailDal.Remove(basketDetail);
            _unitOfWork.SaveChanges();
            return new SuccessResult();
        }
    }
}
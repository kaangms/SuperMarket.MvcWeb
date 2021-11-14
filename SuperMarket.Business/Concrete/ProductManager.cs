using Core.Utilities.Results;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Constants;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.BusinessRules;

namespace SuperMarket.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_unitOfWork.ProductDal.Get(p => p.Id == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_unitOfWork.ProductDal.GetList().ToList());
        }

        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductIdExists(product.Id), CheckIfProductNameExists(product));

            if (result != null) return result;
            _unitOfWork.ProductDal.Add(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.SuccessProductAdded);
        }

        private IResult CheckIfProductIdExists(int productId)
        {
            return (productId == 0)
                ? new SuccessResult()
                : new ErrorResult(Messages.ProductIdExistsForAdd);
        }

        private IResult CheckIfProductNameExists(Product product)
        {
            var result =_unitOfWork.ProductDal.GetList(p => p.ProductName == product.ProductName&& p.Id!=product.Id).Any();
            if (result) return new ErrorResult(Messages.ProductNameAlreadyExists);

            return new SuccessResult();
        }

        public IResult Remove(Product product)
        {
              var result = BusinessRules.Run(CheckIfOnBasketDetailProductExists(product.Id));
              if (result != null) return result;
              _unitOfWork.ProductDal.Remove(product);
              return new SuccessResult(Messages.SuccessProductRemoved);
        }

        private IResult CheckIfOnBasketDetailProductExists(int productId)
        {
        return  _unitOfWork.BasketDetailDal.GetList(bd => bd.ProductId == productId).Count > 0
                ? new ErrorResult(Messages.OnBasketDetailProductExists)
                : new SuccessResult();

        }

        public IResult RemoveByProductId(int productId)
        {
          var product=  GetById(productId).Data;
         var result= Remove(product);
         if (result.Success) _unitOfWork.SaveChanges();

         return result;
        }

        public IResult Update(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameExists(product));
            if (result != null) return result;
            _unitOfWork.ProductDal.Update(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Results;
using Newtonsoft.Json;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Constants;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;

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
            _unitOfWork.ProductDal.Add(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Remove(Product product)
        {
            _unitOfWork.ProductDal.Remove(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult();
        }

        public IResult Update(Product product)
        {
            _unitOfWork.ProductDal.Update(product);
            _unitOfWork.SaveChanges();
            return new SuccessResult();
        }
    }
}

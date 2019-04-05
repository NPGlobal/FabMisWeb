using FabMisWeb.Repository.Contracts;
using FabMisWeb.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabMisWeb.Services.Implementations
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public DataSet GetProductListData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _repository.GetProductListData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}

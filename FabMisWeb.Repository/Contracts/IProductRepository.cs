using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabMisWeb.Repository.Contracts
{
    public interface IProductRepository
    {
        DataSet GetProductListData();
    }
}

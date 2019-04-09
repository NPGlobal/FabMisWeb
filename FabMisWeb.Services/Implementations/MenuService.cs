using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FabMisWeb.Repository.Contracts;
using FabMisWeb.Services.Contracts;

namespace FabMisWeb.Services.Implementations
{
    public class MenuService: IMenuService
    {
        private IMenuRepository _repository;

        public MenuService(IMenuRepository repository)
        {
            _repository = repository;
        }

        public DataSet GetMenuListAndFilterData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _repository.GetMenuListAndFilterData();

                ds.Tables[0].TableName = "MenuList";
                ds.Tables[1].TableName = "FilterData";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}

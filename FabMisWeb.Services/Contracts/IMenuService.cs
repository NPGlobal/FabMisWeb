using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FabMisWeb.Services.Contracts
{
    public interface IMenuService
    {
        DataSet GetMenuListAndFilterData();
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FabMisWeb.Model;
using FabMisWeb.Repository.Contracts;
using Microsoft.Extensions.Options;

namespace FabMisWeb.Repository.Implementations
{
    public class MenuRepository: IMenuRepository
    {
        private IOptions<WebConfiguration> _options;

        public MenuRepository(IOptions<WebConfiguration> options)
        {
            _options = options;
        }

        public DataSet GetMenuListAndFilterData()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(_options.Value.DefaultConnection))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "[FABMIS].[FilterMenuList]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter();
                        sda.SelectCommand = cmd;
                        sda.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
    }
}

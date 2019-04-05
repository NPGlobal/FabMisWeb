using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FabMisWeb.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FabMisWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        private ILogger _logger;
        private IHostingEnvironment _hostingEnvironment;

        public ProductController(IProductService service, IHostingEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("GenerateProductListReport")]
        public DataSet GenerateProductListReport()
        {
            DataSet ds = new DataSet();
            string csvFileName = String.Empty;
            string folderName = String.Empty;
            string webRootPath = String.Empty;
            try
            {
                folderName = Guid.NewGuid().ToString() + ".csv";
                webRootPath = _hostingEnvironment.WebRootPath;
                csvFileName = Path.Combine(webRootPath, "Reports", folderName);
                Directory.CreateDirectory(csvFileName);

                ds = _service.GetProductListData();
                CreateCSVFile(ds.Tables[0], csvFileName);

            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public void CreateCSVFile(DataTable dtDataTablesList, string strFilePath)
        {
            // Create the CSV file to which grid data will be exported.

            StreamWriter sw = new StreamWriter(strFilePath, false);

            //First we will write the headers.

            int iColCount = dtDataTablesList.Columns.Count;

            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dtDataTablesList.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);

            // Now write all the rows.

            foreach (DataRow dr in dtDataTablesList.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)

                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
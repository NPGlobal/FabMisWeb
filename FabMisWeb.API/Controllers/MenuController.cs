using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FabMisWeb.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FabMisWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService _service;
        private ILogger _logger;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetMenuListAndFilterData")]
        public IActionResult GetMenuListAndFilterData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = _service.GetMenuListAndFilterData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(ds);
        }
    }
}
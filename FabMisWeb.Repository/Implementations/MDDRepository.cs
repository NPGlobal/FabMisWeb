using FabMisWeb.Model;
using FabMisWeb.Repository.Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabMisWeb.Repository.Implementations
{
    public class MDDRepository: IMDDRepository
    {
        private IOptions<WebConfiguration> _options;

        public MDDRepository(IOptions<WebConfiguration> options)
        {
            _options = options;
        }
    }
}

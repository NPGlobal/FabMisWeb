using FabMisWeb.Repository.Contracts;
using FabMisWeb.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabMisWeb.Services.Implementations
{
    public class MDDService: IMDDService
    {
        private IMDDRepository _repository;

        MDDService(IMDDRepository repository)
        {
            _repository = repository;
        }
    }
}

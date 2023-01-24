using AgendaApp.Domain.DTO;
using AgendaApp.Domain.Repository.Interfaces;
using AgendaApp.Service.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Service.Impementations
{
    public class AlertTypeService : IAlertTypeService
    {
        private readonly IAlertTypeRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AlertTypeService(
            IAlertTypeRepository repository,            
            IMapper mapper,
            ILogger<AlertTypeService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _logger.LogInformation($"The AlertTypeService was invoked");
        }

        public List<AlertTypeDto> GetAlertTypes()
        {
            _logger.LogInformation($"The AlertTypeService was invoked. Method: GetAlertTypes()");

            var entities = _repository.FindAll().ToList();
            var dto = AlertTypeDto.MapList(entities);

            _logger.LogInformation($"The AlertTypeService was invoked. Method was finished: GetAlertTypes()");

            return dto;
        }
    }
}

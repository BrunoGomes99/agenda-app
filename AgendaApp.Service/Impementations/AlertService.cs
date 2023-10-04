using AgendaApp.Domain.DTO;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Repository.Interfaces;
using AgendaApp.Service.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AgendaApp.Service.Impementations
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository _repository;
        private readonly IRabbitMqService _rabbitMqService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AlertService(
            IMapper mapper,
            IRabbitMqService rabbitMqService,
            IAlertRepository repository,
            ILogger<AlertService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _rabbitMqService = rabbitMqService;
            _repository = repository;
            _logger.LogInformation($"The AlertService was invoked");
        }

        public List<AlertDto> Get()
        {
            _logger.LogInformation($"The AlertService was invoked. Method: Get()");

            var entities = _repository.FindAll().ToList();
            var dto = AlertDto.MapList(entities);

            _logger.LogInformation($"The AlertService was invoked. Method was finished: Get()");

            return dto;
        }

        public AlertDto? GetById(int id)
        {
            _logger.LogInformation($"The AlertService was invoked. Method: GetById({id})");

            var entity = _repository.FindByCondition(x => x.Id == id).FirstOrDefault();
            var dto = _mapper.Map<AlertDto>(entity);

            _logger.LogInformation($"The AlertService was invoked. Method was finished: GetById({id})");

            return dto;
        }

        public AlertDto Save(AlertDto dto)
        {
            _logger.LogInformation($"The AlertService was invoked. Method: Save()");

            var currentDate = DateTime.Now;
            if (dto.Date < currentDate) throw new Exception("Invalid date.");

            var entidade = _mapper.Map<Alert>(dto);
            var result = _repository.CreateWRet(entidade);
            _repository.SaveChanges();

            var jsonResult = JsonSerializer.Serialize(result);
            _rabbitMqService.SendMessage(jsonResult);

            _logger.LogInformation($"The AlertService was invoked. Method was finished: Save()");

            return _mapper.Map<AlertDto>(result);
        }

        public AlertDto Update(AlertDto dto)
        {
            _logger.LogInformation($"The AlertService was invoked. Method: Update()");

            var currentDate = DateTime.Now;
            if (dto.Date < currentDate) throw new Exception("Invalid date.");

            var entidade = _mapper.Map<Alert>(dto);
            _repository.Update(entidade);
            _repository.SaveChanges();

            _logger.LogInformation($"The AlertService was invoked. Method was finished: Update()");

            return _mapper.Map<AlertDto>(entidade);
        }

        public void Delete(int id)
        {
            _logger.LogInformation($"The AlertService was invoked. Method: Delete({id})");

            var entidade = _repository.FindByCondition(x => x.Id == id).First();
            
            _repository.Delete(entidade);
            _repository.SaveChanges();

            _logger.LogInformation($"The AlertService was invoked. Method was finished: Delete({id})");
        }
    }
}

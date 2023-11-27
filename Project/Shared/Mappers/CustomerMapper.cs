using Project.Entities.Model;
using Project.Shared.DTOs;
using System.Collections.Generic;
using OpenWeatherEntity = Project.Entities.Model.OpenWeatherEntity;

namespace Project.Shared.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerEntity MapDTOToEntity(CustomerDTO dto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Address = dto.Address,
                BirthDate = dto.BirthDate,
                CUIT = dto.CUIT,
                Email = dto.Email,
                Phone= dto.Phone
            };
            return entity;
        }

        public static CustomerDTO MapEntityToDTO(CustomerEntity entity)
        {
            CustomerDTO dto = new CustomerDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Address = entity.Address,
                BirthDate = entity.BirthDate,
                CUIT = entity.CUIT,
                Email = entity.Email,
                Phone = entity.Phone
            };
            return dto;
        }

        public static List<CustomerDTO> MapListEntityToDTO(List<CustomerEntity> entity)
            => entity.Select(item => MapEntityToDTO(item)).ToList();

        public static List<CustomerEntity> MapListDTOToEntity(List<CustomerDTO> entity)
            => entity.Select(item => MapDTOToEntity(item)).ToList();

    }
}

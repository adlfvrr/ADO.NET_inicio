using EntityF_proy.DTO;
using EntityF_proy.Exception;
using EntityF_proy.Models;
using EntityF_proy.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityF_proy.Service
{
    public class SamsungService
    {
        private readonly SamsungRepository repo;

        public SamsungService(SamsungRepository repo)
        {
            this.repo = repo;
        }

        public List<SamsungDTO> ObtenerTodos()
        {
            return repo.GetAll()
                .Select(s => PhoneMapper.SamsungToDTO(s))
                .ToList();
        }

        public SamsungDTO AgregarSamsung(SamsungDTO dtoSamsung)
        {
            if (string.IsNullOrEmpty(dtoSamsung.Model) ||
        dtoSamsung.Precio == null || dtoSamsung.Precio <= 0 ||
        string.IsNullOrEmpty(dtoSamsung.Serie))
            {
                throw new DatosIncorrectosException();
            }

            repo.Add(PhoneMapper.SamsungDTOToEntity(dtoSamsung), new Phone { Stock = dtoSamsung.Stock ?? 0, IdType = 2 });
            return dtoSamsung;
        }

        public void ActualizarSamsung(SamsungDTO dtoSamsung)
        {
            if (string.IsNullOrEmpty(dtoSamsung.Model) ||
        dtoSamsung.Precio == null || dtoSamsung.Precio <= 0 ||
        string.IsNullOrEmpty(dtoSamsung.Serie))
            {
                throw new DatosIncorrectosException();
            }

            

            repo.Update(PhoneMapper.SamsungDTOToEntity(dtoSamsung), new Phone { IdPhone = dtoSamsung.Id,Stock = dtoSamsung.Stock ?? 0, IdType = 2 });
        }
    }
}

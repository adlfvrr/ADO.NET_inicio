using EntityF_proy.DTO;
using EntityF_proy.Exception;
using EntityF_proy.Models;
using EntityF_proy.Repository;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EntityF_proy.Service
{
    public class IphoneService
    {

        private readonly IphoneRepository repo;

        public IphoneService(IphoneRepository repo)
        {
            this.repo = repo;
        }

        public List<IphoneDTO> ObtenerTodos()
        {
            return repo.GetAll()
                .Select(i => PhoneMapper.IphoneToDTO(i))
                .ToList();
        }

        public IphoneDTO AgregarIphone(IphoneDTO dtoIphone)
        {
            if (string.IsNullOrEmpty(dtoIphone.Model) ||
        dtoIphone.Precio == null || dtoIphone.Precio <= 0 ||
        string.IsNullOrEmpty(dtoIphone.Cond_bateria))
            {
                throw new DatosIncorrectosException();
            }

            repo.Add(PhoneMapper.IphoneDTOToEntity(dtoIphone), new Phone { Stock = dtoIphone.Stock ?? 0, IdType = 1 });
            return dtoIphone;
        }

        public void ActualizarIphone(IphoneDTO dtoIphone)
        {
            if (string.IsNullOrEmpty(dtoIphone.Model) ||
        dtoIphone.Precio == null || dtoIphone.Precio <= 0 ||
        string.IsNullOrEmpty(dtoIphone.Cond_bateria))
            {
                throw new DatosIncorrectosException();
            }

            repo.Update(PhoneMapper.IphoneDTOToEntity(dtoIphone), new Phone {IdPhone = dtoIphone.Id, Stock = dtoIphone.Stock ?? 0, IdType = 1 });
        }
    }
}

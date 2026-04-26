using PhonesAPIWeb.DTO;
using PhonesAPIWeb.Exception;
using PhonesAPIWeb.Models;
using PhonesAPIWeb.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.Service
{
    public class PhoneService
    {

        private readonly PhoneRepository repo;

        public PhoneService(PhoneRepository repo)
        {
            this.repo = repo;
        }

        public List<PhoneDTO> ObtenerTodos()
        {
            return repo.GetAll()
                .Select(p => p.IdType == 1 ? (PhoneDTO)PhoneMapper.IphoneToDTO(p.Iphone) : (PhoneDTO)PhoneMapper.SamsungToDTO(p.Samsung))
                .ToList();
                
        }

        public PhoneDTO ObtenerPorId(int id)
        {
            if(id <= 0 || id == null)
            {
                throw new IdIncorrectaException(id);
            }

            PhoneDTO dto = null;
            Phone phone = repo.GetById(id);
            if(phone != null)
            {
                if(phone.IdType == 1)
                {
                    dto = PhoneMapper.IphoneToDTO(phone.Iphone);
                }
                else
                {
                    dto = PhoneMapper.SamsungToDTO(phone.Samsung);
                }
            }
            return dto;
        }

        public void Borrar(int id)
        {
            if (id <= 0 || id == null)
            {
                throw new IdIncorrectaException(id);
            }
            repo.Remove(id);
        }
    }
}

using PhonesAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonesAPIWeb.DTO
{
    public class PhoneMapper
    {
        public static Phone PhoneDTOToEntity(PhoneDTO dto)
        {
            Phone phone = new Phone();
            phone.IdPhone = dto.Id;
            phone.Stock = dto.Stock;
            phone.IdType = dto.Tipo;
            return phone;
        }

        public static Iphone IphoneDTOToEntity(IphoneDTO dto)
        {
            Iphone iphone = new Iphone();
            iphone.IdPhone = dto.Id;
            iphone.Price = dto.Precio;
            iphone.Model = dto.Model;
            iphone.CondBateria = dto.Cond_bateria;
            iphone.IdType = 1;
            return iphone;
        }

        public static Samsung SamsungDTOToEntity(SamsungDTO dto)
        {
            Samsung samsung = new Samsung();
            samsung.IdPhone = dto.Id;
            samsung.Price = dto.Precio;
            samsung.Model = dto.Model;
            samsung.Serie = dto.Serie;
            samsung.IdType = 2;
            return samsung;
        }

        public static IphoneDTO IphoneToDTO(Iphone entity)
        {
            IphoneDTO dto = new IphoneDTO();
            dto.Id = entity.IdPhone;
            dto.Tipo = entity.IdType;
            dto.Stock = entity.IdPhoneNavigation.Stock;
            dto.Precio = entity.Price;
            dto.Model = entity.Model;
            dto.Cond_bateria = entity.CondBateria;
            return dto;
        }

        public static SamsungDTO SamsungToDTO(Samsung entity)
        {
            SamsungDTO dto = new SamsungDTO();
            dto.Id = entity.IdPhone;
            dto.Tipo = entity.IdType;
            dto.Stock = entity.IdPhoneNavigation.Stock;
            dto.Precio = entity.Price;
            dto.Model = entity.Model;
            dto.Serie = entity.Serie;
            return dto;
        }

        public static PhoneDTO EntityToDTO(Phone phone)
        {
            PhoneDTO dto = new PhoneDTO();
            dto.Id = phone.IdPhone;
            dto.Stock = phone.Stock;
            dto.Tipo = phone.IdType;
            return dto;
        }
    }
}

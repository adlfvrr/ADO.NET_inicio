using DAO_proy.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.DTOs
{
    public class PhoneMapper
    {
        public static Iphone IphoneDTOToEntity(IphoneDTO dto)
        {
            Iphone iphone = new Iphone();
            iphone.id = dto.id;
            iphone.stock = dto.stock;
            iphone.price = dto.precio;
            iphone.model = dto.model;
            iphone.cond_bateria = dto.cond_bateria;
            iphone.type = 1;
            return iphone;
        }

        public static Samsung SamsungDTOToEntity(SamsungDTO dto)
        {
            Samsung samsung = new Samsung();
            samsung.id = dto.id;
            samsung.stock = dto.stock;
            samsung.price = dto.precio;
            samsung.model = dto.model;
            samsung.serie = dto.serie;
            samsung.type = 2;
            return samsung;
        }

        public static IphoneDTO IphoneToDTO(Iphone entity)
        {
            IphoneDTO dto = new IphoneDTO();
            dto.id = entity.id;
            dto.tipo = entity.type;
            dto.stock = entity.stock;
            dto.precio = entity.price;
            dto.model = entity.model;
            dto.cond_bateria = entity.cond_bateria;
            return dto;
        }

        public static SamsungDTO SamsungToDTO(Samsung entity)
        {
            SamsungDTO dto = new SamsungDTO();
            dto.id = entity.id;
            dto.tipo = entity.type;
            dto.stock = entity.stock;
            dto.precio = entity.price;
            dto.model = entity.model;
            dto.serie = entity.serie;
            return dto;
        }

    }
}

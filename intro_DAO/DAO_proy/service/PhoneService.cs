using DAO_proy.DAOs;
using DAO_proy.DTOs;
using DAO_proy.entity;
using DAO_proy.exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.service
{
    public class PhoneService
    {
        private CelularDAOImpl celularDAO;

        public PhoneService()
        {
            this.celularDAO = new CelularDAOImpl();
        }

        public List<CelularBaseDTO> ObtenerTodos()
        {
            List<CelularBaseDTO> listaDTO = new List<CelularBaseDTO>();
            foreach(Celular c in this.celularDAO.GetAll())
            {
                CelularBaseDTO dto = (c is Iphone) ? PhoneMapper.IphoneToDTO(c as Iphone) : PhoneMapper.SamsungToDTO(c as Samsung);
                if (dto != null)
                {
                    listaDTO.Add(dto);
                }
            }
            return listaDTO;
        }

        public void EliminarCelular(int id)
        {
            if(id <= 0 || id == null)
            {
                throw new IdIncorrectaException(id);
            }
            this.celularDAO.RemovePhone(id);
        }

        #region Iphone

        public List<IphoneDTO> ObtenerTodosIphone()
        {
            List<IphoneDTO> listaDTO = new List<IphoneDTO>();
            foreach(Iphone i in this.celularDAO.GetAllIphone())
            {
                IphoneDTO dto = PhoneMapper.IphoneToDTO(i);
                if(dto != null)
                {
                    listaDTO.Add(dto);
                }
            }
            return listaDTO;
        }

        public IphoneDTO ObtenerIphonePorId(int id)
        {
            if(id <= 0 || id == null)
            {
                throw new IdIncorrectaException(id);
            }
            if(this.celularDAO.GetIphoneById(id) == null)
            {
                throw new EntidadInexistenteException();
            }

            return PhoneMapper.IphoneToDTO(this.celularDAO.GetIphoneById(id));
        }

        public IphoneDTO AgregarIphone(IphoneDTO dto)
        {
            if(dto.stock == null || dto.precio == null || dto.model == null || dto.cond_bateria == null)
            {
                throw new DatosIncorrectosException();
            }
            this.celularDAO.SaveIphone(PhoneMapper.IphoneDTOToEntity(dto));
            return dto;
        }

        public void ActualizarIphone(IphoneDTO dto)
        {
            bool stock = false;
            if(dto.stock != null)
            {
                stock = true;
            }
            //Esta múltiple comprobación es, para cuando yo quiera actualizar una figura seleccionándola en un listbox, se autocompleten los campos necesarios (textbox, checkbox, etc).
            //Por lo tanto, no puede estar en null
            if (dto.stock == null || dto.precio == null || dto.model == null || dto.cond_bateria == null)
            {
                throw new DatosIncorrectosException();
            }
            this.celularDAO.UpdateIphone(PhoneMapper.IphoneDTOToEntity(dto), stock);
        }

        #endregion

        #region Samsung

        public List<SamsungDTO> ObtenerTodosSamsung()
        {
            List<SamsungDTO> listaDTO = new List<SamsungDTO>();
            foreach (Samsung s in this.celularDAO.GetAllSamsung())
            {
                SamsungDTO dto = PhoneMapper.SamsungToDTO(s);
                if (dto != null)
                {
                    listaDTO.Add(dto);
                }
            }
            return listaDTO;
        }

        public SamsungDTO ObtenerSamsungPorId(int id)
        {
            if (id <= 0 || id == null)
            {
                throw new IdIncorrectaException(id);
            }
            if (this.celularDAO.GetSamsungById(id) == null)
            {
                throw new EntidadInexistenteException();
            }
            return PhoneMapper.SamsungToDTO(this.celularDAO.GetSamsungById(id));
        }

        public SamsungDTO AgregarSamsung(SamsungDTO dto)
        {
            if (dto.stock == null || dto.precio == null || dto.model == null || dto.serie == null)
            {
                throw new DatosIncorrectosException();
            }
            this.celularDAO.SaveSamsung(PhoneMapper.SamsungDTOToEntity(dto));
            return dto;
        }

        public void ActualizarSamsung(SamsungDTO dto)
        {
            bool stock = false;
            if (dto.stock != null)
            {
                stock = true;
            }
            //Esta múltiple comprobación es, para cuando yo quiera actualizar una figura seleccionándola en un listbox, se autocompleten los campos necesarios (textbox, checkbox, etc).
            //Por lo tanto, no puede estar en null
            if (dto.stock == null || dto.precio == null || dto.model == null || dto.serie == null)
            {
                throw new DatosIncorrectosException();
            }
            this.celularDAO.UpdateSamsung(PhoneMapper.SamsungDTOToEntity(dto), stock);
        }

        #endregion
    }
}

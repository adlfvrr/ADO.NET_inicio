using DAO_proy.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_proy.DAOs
{
    public interface ICelularDAO
    {
        public List<Celular> GetAll();
        //Iphone
        public List<Iphone> GetAllIphone();
        public Iphone GetIphoneById(int id);
        public Iphone SaveIphone(Iphone entity);
        public void UpdateIphone(Iphone entity, bool stock);
        public void RemovePhone(int id);
        //Samsung
        public List<Samsung> GetAllSamsung();
        public Samsung GetSamsungById(int id);
        public Samsung SaveSamsung(Samsung entity);
        public void UpdateSamsung(Samsung entity, bool stock);
    }
}

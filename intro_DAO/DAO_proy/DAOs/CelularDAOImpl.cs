using DAO_proy.entity;
using DAO_proy.exception;
using Microsoft.EntityFrameworkCore.Query;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DAO_proy.DAOs
{
    public class CelularDAOImpl : ICelularDAO
    {
        private readonly string connectionString = "Host=localhost;Port=5432;Database=your_database;Username=your_user;Password=your_password";

        //Realizamos unos mapper para promover una mayor reutilización de código
        #region MAPPER
        private Iphone IphoneMapper(NpgsqlDataReader reader)
        {
            return new Iphone
            {
                id = Convert.ToInt32(reader["id_phone"]),
                type = Convert.ToInt32(reader["id_type"]),
                stock = Convert.ToInt32(reader["stock"]),
                model = reader["model"].ToString(),
                price = Convert.ToDouble(reader["price"]),
                cond_bateria = reader["cond_bateria"].ToString()
            };
        }

        private Samsung SamsungMapper(NpgsqlDataReader reader)
        {
            return new Samsung
            {
                id = Convert.ToInt32(reader["id_phone"]),
                type = Convert.ToInt32(reader["id_type"]),
                stock = Convert.ToInt32(reader["stock"]),
                model = reader["model"].ToString(),
                price = Convert.ToDouble(reader["price"]),
                serie = reader["serie"].ToString()
            };
        }
        #endregion
        //Empezamos implementando un método para TODOS los celulares
        public List<Celular> GetAll()
        {
            List<Celular> listaCelulares = new List<Celular>();
            string sql = @"SELECT p.id_phone, p.id_type, p.stock,
                         i.model  AS iphone_model,  i.price AS iphone_price,  i.cond_bateria,
                         s.model  AS samsung_model, s.price AS samsung_price, s.serie
                  FROM phones p
                  LEFT JOIN iphone  i ON p.id_phone = i.id_phone
                  LEFT JOIN samsung s ON p.id_phone = s.id_phone";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Celular celular = null;
                    int tipo = reader["id_type"] != DBNull.Value ? Convert.ToInt32(reader["id_type"]) : throw new TipoException();
                    switch (tipo)
                    {
                        case 1:
                            celular = new Iphone
                            {
                                id = Convert.ToInt32(reader["id_phone"]),
                                stock = Convert.ToInt32(reader["stock"]),
                                model = reader["iphone_model"].ToString(),
                                price = Convert.ToDouble(reader["iphone_price"]),
                                cond_bateria = reader["cond_bateria"].ToString()
                            };
                            break;
                        case 2:
                            celular = new Samsung
                            {
                                id = Convert.ToInt32(reader["id_phone"]),
                                stock = Convert.ToInt32(reader["stock"]),
                                model = reader["samsung_model"].ToString(),
                                price = Convert.ToDouble(reader["samsung_price"]),
                                serie = reader["serie"].ToString()
                            };
                            break;
                    }
                    if (celular is Iphone || celular is Samsung)
                    {
                        listaCelulares.Add(celular);
                    }
                }
                return listaCelulares;
            }
            catch (TipoException ex)
            {
                throw new TipoException();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los celulares: " + ex.Message);
            }
        }

        //Ahora implementamos nuestro DAO pero para cada celular en particular
        //Iphone

        #region Iphone DAO
        public List<Iphone> GetAllIphone()
        {
            List<Iphone> listaIphone = new List<Iphone>();
            string sql = @"SELECT p.id_phone, p.id_type, p.stock,
i.model,  i.price,  i.cond_bateria
FROM phones p
INNER JOIN iphone i ON p.id_phone = i.id_phone;";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();

                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaIphone.Add(IphoneMapper(reader));
                }

                return listaIphone;
            }
            catch(Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }

        public Iphone GetIphoneById(int id)
        {
            string sql = @"SELECT p.id_phone, p.id_type, p.stock,
i.model, i.price, i.cond_bateria
FROM phones p
INNER JOIN iphone i on p.id_phone = i.id_phone
WHERE p.id_phone = @id;";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return IphoneMapper(reader);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido una excepcion: {ex.Message}");
            }
        }

        public void RemovePhone(int id)
        {
            string sql = "DELETE FROM phones WHERE id_phone = @id;";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();

                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }

        public void UpdateIphone(Iphone entity, bool stock)
        {
            string sql = @"UPDATE iphone SET
model = @model,
price = @price,
cond_bateria = @cond_bateria
WHERE id_phone = @idPhone;";
            //En caso de actualizar stock tambien, actualizamos:
            string sqlStock = @"UPDATE phones SET
stock = @stock
WHERE id_phone = @idPhone";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();

                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);

                //Establecemos los parámetros antes de ejecutar la query
                cmd.Parameters.AddWithValue("@model", entity.model);
                cmd.Parameters.AddWithValue("@price", entity.price);
                cmd.Parameters.AddWithValue("@cond_bateria", entity.cond_bateria);
                cmd.Parameters.AddWithValue("@idPhone", entity.id);

                cmd.ExecuteNonQuery();

                if (stock)
                {
                    using NpgsqlCommand cmdStock = new NpgsqlCommand(sqlStock, connection);
                    cmdStock.Parameters.AddWithValue("@stock", entity.stock);
                    cmdStock.Parameters.AddWithValue("@idPhone", entity.id);
                    cmdStock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }

        public Iphone SaveIphone(Iphone entity)
        {
            string sqlPhones = @"INSERT INTO phones(id_type,stock) 
VALUES(@id_type, @stock)
RETURNING id_phone;"; //Extraemos el id y lo asignamos a entity
            string sqlIphone = @"INSERT INTO iphone (id_phone, id_type, model, price, cond_bateria) 
                  VALUES (@idPhone, @idType, @model, @price, @condBateria);";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();
                
                using NpgsqlCommand cmdPhones = new NpgsqlCommand(sqlPhones, connection);

                cmdPhones.Parameters.AddWithValue("@id_type", entity.type);
                cmdPhones.Parameters.AddWithValue("@stock", entity.stock);

                int newId = Convert.ToInt32(cmdPhones.ExecuteScalar()); //Ejecutamos el comando y retornamos el numero (RETURNING id_phone)

                using NpgsqlCommand cmdIphone = new NpgsqlCommand(sqlIphone, connection);

                cmdIphone.Parameters.AddWithValue("@idPhone", newId);
                cmdIphone.Parameters.AddWithValue("@idType", entity.type);
                cmdIphone.Parameters.AddWithValue("@model", entity.model);
                cmdIphone.Parameters.AddWithValue("@price", entity.price);
                cmdIphone.Parameters.AddWithValue("@condBateria", entity.cond_bateria);

                entity.id = newId;

                cmdIphone.ExecuteNonQuery();

                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }
        #endregion
        //Samsung
        #region Samsung DAO
        public List<Samsung> GetAllSamsung()
        {
            List<Samsung> listaSamsung = new List<Samsung>();
            string sql = @"SELECT p.id_phone, p.id_type, p.stock,
s.model,  s.price,  s.serie
FROM phones p
INNER JOIN samsung s ON p.id_phone = s.id_phone;";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();

                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaSamsung.Add(SamsungMapper(reader));
                }

                return listaSamsung;
            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }

        public Samsung GetSamsungById(int id)
        {
            string sql = @"SELECT p.id_phone, p.id_type, p.stock,
s.model, s.price, s.serie
FROM phones p
INNER JOIN samsung s on p.id_phone = s.id_phone
WHERE p.id_phone = @id;";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();
                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return SamsungMapper(reader);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido una excepcion: {ex.Message}");
            }
        }

        public void UpdateSamsung(Samsung entity, bool stock)
        {
            string sql = @"UPDATE samsung
SET model = @model,
price = @price,
serie = @serie
WHERE id_phone = @idPhone;";
            //En caso de actualizar stock tambien, actualizamos:
            string sqlStock = @"UPDATE phones SET
stock = @stock
WHERE id_phone = @idPhone";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();

                using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);

                //Establecemos los parámetros antes de ejecutar la query
                cmd.Parameters.AddWithValue("@model", entity.model);
                cmd.Parameters.AddWithValue("@price", entity.price);
                cmd.Parameters.AddWithValue("@serie", entity.serie);
                cmd.Parameters.AddWithValue("@idPhone", entity.id);

                cmd.ExecuteNonQuery();

                if (stock)
                {
                    using NpgsqlCommand cmdStock = new NpgsqlCommand(sqlStock, connection);
                    cmdStock.Parameters.AddWithValue("@stock", entity.stock);
                    cmdStock.Parameters.AddWithValue("@idPhone", entity.id);
                    cmdStock.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }

        public Samsung SaveSamsung(Samsung entity)
        {
            string sqlPhones = @"INSERT INTO phones(id_type,stock) 
VALUES(@id_type, @stock)
RETURNING id_phone;"; //Extraemos el id y lo asignamos a entity
            string sqlSamsung = @"INSERT INTO samsung (id_phone, id_type, model, price, serie) 
                  VALUES (@idPhone, @idType, @model, @price, @serie);";
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);
                connection.Open();

                using NpgsqlCommand cmdPhones = new NpgsqlCommand(sqlPhones, connection);

                cmdPhones.Parameters.AddWithValue("@id_type", entity.type);
                cmdPhones.Parameters.AddWithValue("@stock", entity.stock);

                int newId = Convert.ToInt32(cmdPhones.ExecuteScalar()); //Ejecutamos el comando y retornamos el numero (RETURNING id_phone)

                using NpgsqlCommand cmdSamsung = new NpgsqlCommand(sqlSamsung, connection);

                cmdSamsung.Parameters.AddWithValue("@idPhone", newId);
                cmdSamsung.Parameters.AddWithValue("@idType", entity.type);
                cmdSamsung.Parameters.AddWithValue("@model", entity.model);
                cmdSamsung.Parameters.AddWithValue("@price", entity.price);
                cmdSamsung.Parameters.AddWithValue("@serie", entity.serie);

                entity.id = newId;

                cmdSamsung.ExecuteNonQuery();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido una excepción: {ex.Message}");
            }
        }
        #endregion
    }
}

using FamilyDogs.Domain;
using FamilyDogs.Models.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyDogs.Services
{
    public class DogService : BaseService
    {
        static string _connection = GetConnection();

        //Inserts a record into the database and returns an Id
        public int Create(DogsCreateRequest model)
        {

            int Id = 0;
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spFamilyDogs_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Breed", model.Breed);
                cmd.Parameters.AddWithValue("@Color", model.Color ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Size", model.Size);
                cmd.Parameters.AddWithValue("@LivingArea", model.LivingArea);
                cmd.Parameters.AddWithValue("@LifeExpt", model.LifeExpectancy);
                cmd.Parameters.AddWithValue("@ShedScore", model.ShedScore);
                cmd.Parameters.AddWithValue("@AggressiveScore", model.AgressiveScore);
                cmd.Parameters.AddWithValue("@ExerciseScore", model.ExerciseScore);
                cmd.Parameters.AddWithValue("@ImageUrl", model.Image ?? (object)DBNull.Value);


                SqlParameter outParam = new SqlParameter("@Id", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);              

                conn.Open();
                cmd.ExecuteNonQuery();

                Id = Convert.ToInt32(cmd.Parameters["@Id"].Value);

                return Id;
            }

        }



        //Updates a record into the database and returns an Id
        public void Update(DogsUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spFamilyDogs_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Breed", model.Breed);
                cmd.Parameters.AddWithValue("@Color", model.Color ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Size", model.Size);
                cmd.Parameters.AddWithValue("@LivingArea", model.LivingArea);
                cmd.Parameters.AddWithValue("@LifeExpt", model.LifeExpectancy);
                cmd.Parameters.AddWithValue("@ShedScore", model.ShedScore);
                cmd.Parameters.AddWithValue("@AggressiveScore", model.AgressiveScore);
                cmd.Parameters.AddWithValue("@ExerciseScore", model.ExerciseScore);
                cmd.Parameters.AddWithValue("@ImageUrl", model.Image ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                conn.Open();
                cmd.ExecuteNonQuery();

            }

        }



        //Reading properties from the datbase
        private Dog GetAllProperties(SqlDataReader reader)
        {
            Dog dogSelect = new Dog();

            dogSelect.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            dogSelect.Name = reader.GetString(reader.GetOrdinal("Name"));
            dogSelect.Breed = reader.GetString(reader.GetOrdinal("Breed"));
            dogSelect.Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : "";
            dogSelect.Size = reader.GetString(reader.GetOrdinal("Size"));
            dogSelect.LivingArea = reader.GetString(reader.GetOrdinal("LivingArea"));
            dogSelect.LifeExpectancy = reader.GetString(reader.GetOrdinal("LifeExpt"));
            dogSelect.ShedScore = reader.GetInt32(reader.GetOrdinal("ShedScore"));
            dogSelect.AgressiveScore = reader.GetInt32(reader.GetOrdinal("AgressiveScore"));
            dogSelect.ExerciseScore = reader.GetInt32(reader.GetOrdinal("ExerciseScore"));
            dogSelect.TotalScore = reader.GetInt32(reader.GetOrdinal("TotalScore"));
            dogSelect.Image = reader["ImageUrl"] != DBNull.Value ? reader["ImageUrl"].ToString() : "";
            dogSelect.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateAdded"));
            dogSelect.DateModified = reader.GetDateTime(reader.GetOrdinal("DateModified"));

            return dogSelect;

        }



        //Select all records from database
        public List<Dog> GetAll()
        {
            List<Dog> list = new List<Dog>();
            using (SqlConnection conn = new SqlConnection(_connection))
            {                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spFamilyDogs_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dog dogSelect = GetAllProperties(reader);
                    list.Add(dogSelect);                 
                }

                return list;
            }
        }



        //Select a single record from database
        public Dog GetById(int id)
        {
            Dog singleDog = new Dog();
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spFamilyDogs_GetById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    singleDog = GetAllProperties(reader);
                }

                return singleDog;
            }
        }



        //Delete a single record from the database
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spFamilyDogs_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteScalar();
       
            }

        }
    }
}
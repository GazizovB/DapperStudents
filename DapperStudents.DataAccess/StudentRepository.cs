using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperStudents.Models;

namespace DapperStudents.DataAccess
{
    public class StudentRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\бауыржан\мой документы\visual studio 2015\Projects\DapperStudents.ConsoleApp\DapperStudents.DataAccess\StudentDB.mdf;Integrated Security=True";

        //Method InsertStudent
        public string InsertStudent(string query, Student student)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, student);
                if (result < 1) throw new Exception("Ошибка при вставке записи студента");
            }
            return "Вставка произошла успешно";
        }

        //Method Delete
        public void DeleteStudent(string query, int id)
        {
            using (var sql = new SqlConnection(connectionString))
            {

                sql.Execute(query, new { Id = id });
            }
            //return "Удаление произошла успешно";
        }

        //Method Update
        //public void UpdateStudent(string query, int id)
        //{
        //    using (var sql = new SqlConnection(connectionString))
        //    {
        //        var sqlQuery = "UPDATE Students SET Name = @Name, Age = @Age WHERE Id = @Id";
        //        //sqlQuery.Execute(sqlQuery, user);
        //    }
        //}


        //Create method GetAllStudent
        public List<Student> GetAllStudent(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                return sql.Query<Student>(query).ToList();
            }
        }

        public int Insert<T>(string query, T data)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                return sql.Execute(query, data);
            }
        }
    }
}

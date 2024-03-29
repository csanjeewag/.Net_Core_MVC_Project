﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using test_User.Models;
using System.Configuration;
using System.Data;
using System.Reflection;
using test_User.IRepository;

namespace test_User.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DataContext _dataContext;
        public StudentRepository(IConfiguration configuration)
        {
            _dataContext = new DataContext(configuration);
        }
        public Boolean Create(Student obj)
        {
            
            String sql =    $"INSERT INTO Student " +
                            $"(Name,Birthday,RegisterDate,ALStream)" +
                            $"values( " +
                            $"'{obj.Name}', " +
                            $"'{obj.Birthday}', " +
                            $"'{obj.RegisterDate}', " +
                            $"'{obj.ALStream}')";

            return _dataContext.pushData(sql);

        }

        public Boolean Edit(Student obj)
        {
            String sql =    $"UPDATE student SET " +
                            $"Name = '{obj.Name}' " +
                            $",Birthday = '{obj.Birthday}'" +
                            $",RegisterDate = '{ obj.RegisterDate}' " +
                            $",ALStream = '{obj.ALStream}'" +
                            $"WHERE Id = '{obj.Id}'" ;

            return _dataContext.pushData(sql);

        }
        

        public List<Student> GetAll()
        {
          
            List<Student> students = new List<Student>();

            String sql = $"SELECT * FROM student";

            DataTable dataTable  = _dataContext.PullData(sql);

            students = DataContext.ConvertDataTable<Student>(dataTable);

            return students;


        }

        public Student GetById(int id)
        {
            List<Student> students = new List<Student>();

            String sql = $"SELECT * FROM student WHERE id={id}";


            DataTable dataTable = _dataContext.PullData(sql);
            students = DataContext.ConvertDataTable<Student>(dataTable);

            return students[0];

        }

        public Student DeleteById(int id)
        {
            List<Student> students = new List<Student>();

            String sql = $"DELETE FROM student WHERE id={id}";


            DataTable dataTable = _dataContext.PullData(sql);
            students = DataContext.ConvertDataTable<Student>(dataTable);

            return students[0];

        }

        public List<Student> SeachByName(String str)
        {
            

            List<Student> students = new List<Student>();

            String sql = $"SELECT * FROM student WHERE Name LIKE '%{str.Trim().ToLower()}%'";

            DataTable dataTable = _dataContext.PullData(sql);
            students = DataContext.ConvertDataTable<Student>(dataTable);

            return students;
        }



    }

}

    


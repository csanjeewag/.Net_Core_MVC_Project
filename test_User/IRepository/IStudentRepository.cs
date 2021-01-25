using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_User.Models;

namespace test_User.IRepository
{
    public interface IStudentRepository
    {
        public Boolean Create(Student obj);
        public Boolean Edit(Student obj);
        public List<Student> GetAll();
        public Student GetById(int id);
        public Student DeleteById(int id);

        public List<Student> SeachByName(String str);
    }
}

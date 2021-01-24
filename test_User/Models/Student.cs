using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_User.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter your Name")]
        [Display(Name = "Name")]
        [MinLength(4)]
        public String Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        public DateTime RegisterDate { get; set; }

        [Required(ErrorMessage = "please enter your ALStream")]
        public String ALStream { get; set; }

        public List<String> Streams()
        {
            List<String> streams = new List<String>();
            streams.Add("Maths");
            streams.Add("Science");
            streams.Add("Commerce");
            return streams;
        }

               
    }
}

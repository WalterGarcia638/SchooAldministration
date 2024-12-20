﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystemApi.Model.DTO
{
    public class StudentDTO
    {
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

    
        public int Age { get; set; }

     
        public DateTime DateOfBirth { get; set; }

  
        public string Address { get; set; }


        public int CourseId { get; set; }
        public string Gender { get; set; }
    }
}

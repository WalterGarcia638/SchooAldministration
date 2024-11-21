using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystemApi.Model.DTO.GradeDTO
{
    public class GradeDTO
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }

    }
}


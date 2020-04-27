using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zwierzoki.DTOs
{
    public class AddAnimalRequest
    {
        [Required]
        public int IdAnimal { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime AdmissionDate  { get; set; }
        [Required]
        public int IdOwner { get; set; }
        public int IdProcedure { get; set; }
        public DateTime Date { get; set; }
    }
}

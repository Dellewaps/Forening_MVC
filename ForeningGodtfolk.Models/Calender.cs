using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ForeningGodtfolk.Models
{
    public class Calender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Overskrift")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Beskrivelse")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Dato")]
        public DateOnly Date { get; set; }
        [Required]
        [DisplayName("Tema")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
    }
}

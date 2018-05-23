using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulerWebApi.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(4000)]
        public string Description { get; set; }
    }
}
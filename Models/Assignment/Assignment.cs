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
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.DateTime),DisplayFormat(DataFormatString = "{yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DueDateTime { get; set; }
    }
}
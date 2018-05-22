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
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        [Required]
        [DataType(DataType.Time),DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        
        [Required]
        [DataType(DataType.Time),DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
    }
}
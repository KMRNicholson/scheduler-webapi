using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations.Schema;
using SchedulerWebApi.Models;

namespace SchedulerWebApi.Models
{
    public partial class CourseAppointment
    {
        public int CourseId { get; set; }
        
        public int AppointmentId { get; set; }
    }
}
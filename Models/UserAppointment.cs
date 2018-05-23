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
    public partial class UserAppointment
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
    }
}
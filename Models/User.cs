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
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    
        public Dictionary<string, object> ValidateUser(User user)
        {
            Type type = typeof(User);
            List<string> errors = new List<string>();
            PropertyInfo[] properties = type.GetProperties();
            Dictionary<string, object> responseBody = new Dictionary<string, object>();
            Regex passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$");

            foreach(PropertyInfo property in properties)
            {
                if(String.IsNullOrWhiteSpace(property.GetValue(user, null)?.ToString() ?? ""))
                {
                    errors.Add("Missing Field.");
                }
            }

            try 
            {
                MailAddress m = new MailAddress(user.Email);
            }
            catch(Exception)
            {
                errors.Add("Invalid Format.");
            }

            if(!passwordRegex.IsMatch(user.Password)) errors.Add("Invalid Format.");
            
            if(errors.Count() > 0)
            {
                responseBody.Add("errors", errors);
                return responseBody;
            }

            return responseBody;
        }
    }
}
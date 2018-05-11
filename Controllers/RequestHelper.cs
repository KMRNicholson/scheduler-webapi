using Microsoft.AspNetCore.Mvc;
using System.Web;
using SchedulerWebApi.Models;

namespace SchedulerWebApi.Controllers
{
    public partial class RequestHelper
    {
        public ActionResult Success(object value)
        {
            JsonResult response = new JsonResult(value);
            response.StatusCode = 200;
            return response;
        }

        public ActionResult NotFound()
        {
            JsonResult response = new JsonResult(new {});
            response.StatusCode = 404;
            return response;
        }

        public ActionResult Unauthorized()
        {
            JsonResult response = new JsonResult(new {});
            response.StatusCode = 401;
            return response;
        }

        public ActionResult BadRequest(object value)
        {
            JsonResult response = new JsonResult(value);
            response.StatusCode = 500;
            return response;
        }
    }
    
}
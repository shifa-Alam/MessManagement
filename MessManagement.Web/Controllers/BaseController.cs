using Microsoft.AspNetCore.Mvc;
using MM.Core.Entities;
using MM.Core.Models;
using MM.Core.Services;


namespace MessManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public abstract class BaseController : ControllerBase, IDisposable
    {
        public abstract void Dispose();
        
    }
}
using BakePie;
using Microsoft.AspNetCore.Mvc;

namespace RhubarbFillingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RhubarbFillingServiceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Filling> Get()
        {
            Filling rhubarbPieFilling = new Filling(FillingType.Rhubarb);
            rhubarbPieFilling.isDone = true;
            return rhubarbPieFilling;      
        }
    }
}
using BakePie;
using Microsoft.AspNetCore.Mvc;

namespace RhubarbFillingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RhubarbFillingServiceController : ControllerBase
    {
        [HttpGet]
        //public Filling Get()
        public ActionResult<Filling> Get()
            //public Filling Get()
        {
            Filling rhubarbPieFilling = new Filling(FillingType.Rhubarb);
            rhubarbPieFilling.isDone = true;
            return rhubarbPieFilling;

            //List<Filling> fillingList = new List<Filling>();
            //fillingList.Add(rhubarbPieFilling); 
            //return fillingList;            
        }
    }
}
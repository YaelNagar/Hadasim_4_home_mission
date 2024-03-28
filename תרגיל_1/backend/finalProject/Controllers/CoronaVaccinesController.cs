using BL.interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaVaccinesController : Controller
    {
        ICoronaVaccinesBL coronaVaccinesBL;

        public CoronaVaccinesController(ICoronaVaccinesBL coronaVaccinesBL)
        {
            this.coronaVaccinesBL = coronaVaccinesBL;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CoronaVaccinesDTO> c = coronaVaccinesBL.GetAll();
            return Ok(c);
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            CoronaVaccinesDTO c = coronaVaccinesBL.GetById(id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
    }
}

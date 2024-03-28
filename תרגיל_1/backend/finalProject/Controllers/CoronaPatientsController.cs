using BL.interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaPatientsController : Controller
    {
        ICoronaPatientsBL coronaPatientsBL;

        public CoronaPatientsController(ICoronaPatientsBL coronaPatientsBL)
        {
            this.coronaPatientsBL = coronaPatientsBL;
        }

        [Route("GetByIdMember/{idMember}")]
        [HttpGet]
        public IActionResult GetById(int idMember)
        {
            List<CoronaPatientsDTO> p = coronaPatientsBL.GetByIdMember(idMember);
            if (p == null)
                return NotFound();
            return Ok(p);
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] CoronaPatientsDTO coronaPatientsDTO)
        {
            try
            {
                return Ok(coronaPatientsBL.Add(coronaPatientsDTO));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("LastMonthCoronaPatients")]
        [HttpGet]
        public IActionResult LastMonthCoronaPatients()
        {
            return Ok(coronaPatientsBL.LastMonthCoronaPatients());
        }
    }
}

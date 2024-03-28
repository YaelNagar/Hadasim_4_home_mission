using BL.interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineToMemberController : Controller
    {
        IVaccineToMemberBL vaccineToMemberBL;

        public VaccineToMemberController(IVaccineToMemberBL vaccineToMemberBL)
        {
            this.vaccineToMemberBL = vaccineToMemberBL;
        }

        [Route("GetByIdMember/{idMember}")]
        [HttpGet]
        public IActionResult GetById(int idMember)
        {
            List<VaccineToMemberDTO> v = vaccineToMemberBL.GetByIdMember(idMember);
            if (v == null)
                return NotFound();
            return Ok(v);
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] VaccineToMemberDTO v)
        {
            try
            {
                return Ok(vaccineToMemberBL.Add(v));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [Route("CountMemberVaccine")]
        [HttpGet]
        public IActionResult CountMemberVaccine()
        {
            return Ok(vaccineToMemberBL.CountMemberVaccine());
        }
    }
}

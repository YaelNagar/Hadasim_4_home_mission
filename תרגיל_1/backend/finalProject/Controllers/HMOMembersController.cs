using BL.classes;
using BL.interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HMOMembersController : Controller
    {
        IHMOMembersBL hmoMembersBL;

        public HMOMembersController(IHMOMembersBL hmoMembersBL)
        {
            this.hmoMembersBL = hmoMembersBL;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<HMOMembersDTO> m = hmoMembersBL.GetAll();
            return Ok(m);
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            HMOMembersDTO m = hmoMembersBL.GetById(id);
            if (m == null)
                return NotFound();
            return Ok(m);
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] HMOMembersDTO m)
        {
            try
            {
                return Ok(hmoMembersBL.Add(m));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult Update([FromBody] HMOMembersDTO m)
        {
            try
            {
                return Ok(hmoMembersBL.Update(m));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(hmoMembersBL.Delete(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

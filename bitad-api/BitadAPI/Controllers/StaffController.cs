﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitadAPI.Dto;
using BitadAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BitadAPI.Controllers
{
    [Route("[controller]")]
    public class StaffController : Controller
    {
        private IStaffService staffService;
        private IJwtService _jwtService;

        public StaffController(IStaffService service, IJwtService jwtService)
        {
            staffService = service;
            _jwtService = jwtService;
        }

        [HttpGet("GetStaff")]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaff()
        {
            return Ok(await staffService.GetAll());
        }

        [HttpGet("GetStaffAdmin")]
        [Authorize]
        public async Task<ActionResult<ICollection<DtoStaff>>> GetStaffAdmin()
        {
            var id = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
            var presentedToken = HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (await _jwtService.CheckAuthorization(id, presentedToken) is UnauthorizedResult)
            {
                return Unauthorized();
            }
            var result = await staffService.GetAllAdmin(id);
            HttpContext.Response.Headers.Add("AuthToken", result.Token);
            return Ok(result.Body);
        }
    }
}

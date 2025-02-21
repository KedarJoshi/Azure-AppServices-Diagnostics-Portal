﻿using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using AppLensV3.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppLensV3.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace AppLensV3.Controllers
{
    [Route("api/graph/")]
    [Authorize]
    public class GraphController : Controller
    {
        private readonly IGraphClientService _graphClientService;

        public GraphController(IGraphClientService graphClientService, IDiagnosticClientService diagnosticClient)
        {
            _graphClientService = graphClientService;
        }

        [HttpGet("userPhotos/{userId}")]
        [HttpOptions("userPhotos/{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("userId cannot be empty");
            }

            var response = await _graphClientService.GetOrCreateUserImageAsync(userId);
            return Ok(response);
        }

        [HttpPost("userPhotos")]
        [HttpOptions("userPhotos")]
        public async Task<IActionResult> GetUsers([FromBody]JToken body)
        {
            string[] authors = new string[] { };
            if (body != null && body["authors"] != null)
            {
                authors = body["authors"].ToObject<string[]>();
            }

            var response = await _graphClientService.GetUsers(authors);
            return Ok(response);
        }

        [HttpGet("users/{userId}")]
        [HttpOptions("users/{userId}")]
        public async Task<IActionResult> GetUserInfo(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("userId cannot be empty");
            }

            var response = await _graphClientService.GetUserInfoAsync(userId);
            return Ok(response);
        }

        [HttpGet("hasApplensAccess/{userId}")]
        [HttpOptions("hasApplensAccess/{userId}")]
        public IActionResult CheckApplensAccess(string userId){
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("userId cannot be empty");
            }

            //Will add the logic to check SG once admin consent is approved to read directory
            return Ok(true);
        }

        [HttpGet("hasTestersAccess/{userId}")]
        [HttpOptions("hasTestersAccess/{userId}")]
        public IActionResult CheckTestersAccess(string userId){
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("userId cannot be empty");
            }

            //Will add the logic to check SG once admin consent is approved to read directory
            return Ok(_graphClientService.CheckSecurityGroup(userId));
        }
    }
}

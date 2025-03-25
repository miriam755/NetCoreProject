using AutoMapper;
using FinishProject.API.Models;
using FinishProject.Core.DTOs;
using FinishProject.Core.Models;
using FinishProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinishProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        // GET: api/request
        [HttpGet]
        public async Task<IActionResult> GetAllRequestsAsync()
        {
            var requests = await _requestService.GetAllRequestsAsync();
            var requestsDto = _mapper.Map<IEnumerable<RequestDto>>(requests);
            return Ok(requestsDto);
        }

        // GET api/request/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestAsync(int id)
        {
            var request = await _requestService.GetRequestByIdAsync(id);
            if (request == null) return NotFound($"Request with ID {id} not found");
            var requestDto = _mapper.Map<RequestDto>(request);
            return Ok(requestDto);
        }

        // POST api/request
        [HttpPost]
       

            public async Task<IActionResult> AddRequestAsync(Request request)
            { 
            if (request == null)
               
                return BadRequest("Invalid request data");
         await   _requestService.AddRequestAsync(request);
              
             
                return Ok(request); // מחזיר את הבקשה שנוספה
            }

            // PUT api/request/5
            [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestAsync(int id, [FromBody] Request updatedRequest)
        {
            if (updatedRequest == null || id != updatedRequest.Id)
                return BadRequest("Invalid request data");

            var existingRequest = await _requestService.GetRequestByIdAsync(id);
            if (existingRequest == null)
                return NotFound($"Request with ID {id} not found");

            await _requestService.UpdateRequestAsync(updatedRequest);
            return NoContent(); // 204 No Content
        }

        // DELETE api/request/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestAsync(int id)
        {
            var existingRequest = await _requestService.GetRequestByIdAsync(id);
            if (existingRequest == null)
                return NotFound($"Request with ID {id} not found");

            await _requestService.DeleteRequestAsync(id);
            return NoContent();
        }
    }
}

using AutoMapper;
using FinishProject.API.Models;
using FinishProject.Core.DTOs;
using FinishProject.Core.Models;
using FinishProject.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinishProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeLogController : ControllerBase
    {
        private readonly ITimeLogService _timeLogService;
        private readonly IMapper _mapper;

        public TimeLogController(ITimeLogService timeLogService, IMapper mapper)
        {
            _timeLogService = timeLogService;
            _mapper = mapper;
        }

        // GET: api/<TimeLogController>
        [HttpGet]
        public async Task<ActionResult> GetAllTimeLogsAsync()
        {
            var timeLogs = await _timeLogService.GetListAsync();
            var timeLogDto = _mapper.Map<IEnumerable<TimeLogDto>>(timeLogs);
            return Ok(timeLogDto);
        }

        // GET api/<TimeLogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTimeLogByIdAsync(int id)
        {
            var timeLog = await _timeLogService.GetTimeLogAsync(id);
            if (timeLog == null) return NotFound($"TimeLog with ID {id} not found");
            var timeLogDto = _mapper.Map<TimeLogDto>(timeLog);
            return Ok(timeLogDto);
        }

        // POST api/<TimeLogController>
        [HttpPost]
        public async Task<IActionResult> CreateTimeLogAsync([FromBody] TimeLogDto timeLogDto)
        {
            if (timeLogDto == null)
                return BadRequest("Invalid time log data");
            var timeLogToAdd = _mapper.Map<TimeLog>(timeLogDto);
            var newTimeLog = await _timeLogService.AddAsync(timeLogToAdd);
            return CreatedAtAction(nameof(GetTimeLogByIdAsync), new { id = newTimeLog.Id }, newTimeLog);
        }

        // PUT api/<TimeLogController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeLogAsync(int id, [FromBody] TimeLogDto updatedTimeLogDto)
        {
            if (updatedTimeLogDto == null || id != updatedTimeLogDto.Id)
                return BadRequest("Invalid time log data");

            var existingTimeLog = await _timeLogService.GetTimeLogAsync(id);
            if (existingTimeLog == null)
                return NotFound($"TimeLog with ID {id} not found");

            var timeLogToUpdate = _mapper.Map<TimeLog>(updatedTimeLogDto);
            await _timeLogService.UpdateAsync(timeLogToUpdate);
            return NoContent(); // 204 No Content
        }

        // DELETE api/<TimeLogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeLogAsync(int id)
        {
            var existingTimeLog = await _timeLogService.GetTimeLogAsync(id);
            if (existingTimeLog == null)
                return NotFound($"TimeLog with ID {id} not found");

            await _timeLogService.DeleteAsync(id);
            return NoContent();
        }
    }
}

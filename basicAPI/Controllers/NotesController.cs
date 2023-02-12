using basicAPI.Data.Repositories;
using basicAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace basicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            return Ok(await _noteRepository.GetAllNotes());
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _noteRepository.GetDetails(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateNote([FromBody] Note note)
        {
            if (note == null)           
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _noteRepository.InsertNote(note);

            return Created("created!", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNote([FromBody] Note note)
        {
            if (note == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _noteRepository.UpdateNote(note);

            return NoContent();
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteNote(int id)
        {
            await _noteRepository.DeleteNote(new Note { Id = id });

            return NoContent();
        }
    }
}

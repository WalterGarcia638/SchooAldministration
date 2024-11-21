using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemApi.Model;
using SchoolSystemApi.Repository.IRepository;

namespace SchoolSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _TeacherRepository;
        public TeacherController(ITeacherRepository TeacherRepository)
        {
            _TeacherRepository = TeacherRepository;
        }

        [HttpGet]
        public IActionResult GetTeacher()
        {
            var TeacherList = _TeacherRepository.GetTeachers();

            return Ok(TeacherList);

        }

        [HttpGet("GetById")]
        public IActionResult GeTeachertById([FromQuery] int id)
        {
            var Teacher = _TeacherRepository.GetTeacher(id);

            if (Teacher == null)
            {
                return NotFound();
            }

            return Ok(Teacher);

        }

        [HttpGet("{name}", Name = "GetTeacherByName")]
        public IActionResult GetTeacherByName(string name)
        {
            var Teacher = _TeacherRepository.GetTeacherByName(name);

            if (Teacher == null)
            {
                return NotFound();
            }

            return Ok(Teacher);

        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] Teacher Teacher)
        {
            if (Teacher == null)
            {
                return BadRequest(ModelState);
            }
            if (_TeacherRepository.ExistTeacher(Teacher.FirstName))
            {
                ModelState.AddModelError("", "The Teacher is Exist");
                return StatusCode(500, ModelState);
            }

            if (!_TeacherRepository.CreateTeacher(Teacher))
            {
                ModelState.AddModelError("", $"Error Saving{Teacher.FirstName}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpPatch("{TeacherId:int}", Name = "UpdateTeacher")]
        public IActionResult UpdateTeacher(int TeacherId, [FromBody] Teacher Teacher)
        {
            if (Teacher == null || TeacherId == null || Teacher.Id == 0)
            {
                return BadRequest(ModelState);
            }

            if (!_TeacherRepository.UpdateTeacher(Teacher))
            {
                ModelState.AddModelError("", $"Error Update {Teacher.FirstName}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{TeacherId:int}", Name = "DeleteTeacher")]
        public IActionResult DeleteTeacher(int TeacherId)
        {
            if (!_TeacherRepository.ExistTeacher(TeacherId))
            {
                return NotFound();
            }

            var Teacher = _TeacherRepository.GetTeacher(TeacherId);

            if (!_TeacherRepository.DeleteTeacher(Teacher))
            {
                ModelState.AddModelError("", $"Error Delete {TeacherId}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
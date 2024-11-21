using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemApi.Model;
using SchoolSystemApi.Model.DTO;
using SchoolSystemApi.Model.DTO.StudentGradeDetailDTO;
using SchoolSystemApi.Repository.IRepository;

namespace SchoolSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGradeDetailController : ControllerBase
    {
        private readonly IStudentGradeDetailRepository _StudentGradeDetailRepository;
        private readonly IMapper _mapper;
        public StudentGradeDetailController(IStudentGradeDetailRepository StudentGradeDetailRepository, IMapper mapper)
        {
            _StudentGradeDetailRepository = StudentGradeDetailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudentGradeDetail()
        {
            var StudentGradeDetailList = _StudentGradeDetailRepository.GetStudentGradeDetails();

            return Ok(StudentGradeDetailList);

        }

        [HttpGet("GetById")]
        public IActionResult GeStudentGradeDetailtById([FromQuery] int id)
        {
            var StudentGradeDetail = _StudentGradeDetailRepository.GetStudentGradeDetail(id);

            if (StudentGradeDetail == null)
            {
                return NotFound();
            }

            return Ok(StudentGradeDetail);

        }

        [HttpPost]
        public IActionResult CreateStudentGradeDetail([FromBody] StudentGradeDetailDTO StudentGradeDetailDto)
        {
            if (StudentGradeDetailDto == null)
            {
                return BadRequest(ModelState);
            }
            var studentGradeDetail = _mapper.Map<StudentGradeDetail>(StudentGradeDetailDto);

            if (!_StudentGradeDetailRepository.CreateStudentGradeDetail(studentGradeDetail))
            {
                ModelState.AddModelError("", $"Error Saving{StudentGradeDetailDto.StudentId}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpPatch("{StudentGradeDetailId:int}", Name = "UpdateStudentGradeDetail")]
        public IActionResult UpdateStudentGradeDetail(int StudentGradeDetailId, [FromBody] UpdateStudentGradeDetailDTO StudentGradeDetailDTO)
        {
            if (StudentGradeDetailDTO == null || StudentGradeDetailId == null || StudentGradeDetailDTO.Id == 0)
            {
                return BadRequest(ModelState);
            }

            var studentGradeDetail = _mapper.Map<StudentGradeDetail>(StudentGradeDetailDTO);

            if (!_StudentGradeDetailRepository.UpdateStudentGradeDetail(studentGradeDetail))
            {
                ModelState.AddModelError("", $"Error Update {studentGradeDetail.Id}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{StudentGradeDetailId:int}", Name = "DeleteStudentGradeDetail")]
        public IActionResult DeleteStudentGradeDetail(int StudentGradeDetailId)
        {
            if (!_StudentGradeDetailRepository.ExistStudentGradeDetail(StudentGradeDetailId))
            {
                return NotFound();
            }

            var StudentGradeDetail = _StudentGradeDetailRepository.GetStudentGradeDetail(StudentGradeDetailId);

            if (!_StudentGradeDetailRepository.DeleteStudentGradeDetail(StudentGradeDetail))
            {
                ModelState.AddModelError("", $"Error Delete {StudentGradeDetailId}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
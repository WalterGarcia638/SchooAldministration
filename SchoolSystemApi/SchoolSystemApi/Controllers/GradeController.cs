using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemApi.Model.DTO;
using SchoolSystemApi.Model;
using SchoolSystemApi.Repository.IRepository;
using SchoolSystemApi.Model.DTO.GradeDTO;

namespace SchoolSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _GradeRepository;
        private readonly IMapper _mapper;
        public GradeController(IGradeRepository GradeRepository, IMapper mapper)
        {
            _GradeRepository = GradeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGrade()
        {
            var GradeList = _GradeRepository.GetGrades();
            var GradeDTOList = _mapper.Map<ICollection<GetGradeDTO>>(GradeList);

            return Ok(GradeDTOList);

        }

        [HttpGet("GetById")]
        public IActionResult GeGradetById([FromQuery] int id)
        {
            var Grade = _GradeRepository.GetGrade(id);

            if (Grade == null)
            {
                return NotFound();
            }

            return Ok(Grade);

        }

        [HttpGet("{name}", Name = "GetGradeByName")]
        public IActionResult GetGradeByName(string name)
        {
            var Grade = _GradeRepository.GetGradeByName(name);

            if (Grade == null)
            {
                return NotFound();
            }

            return Ok(Grade);

        }

        [HttpPost]
        public IActionResult CreateGrade([FromBody] GradeDTO GradeDto)
        {
            if (GradeDto == null)
            {
                return BadRequest(ModelState);
            }

            var Grade = _mapper.Map<Grade>(GradeDto);

            if (!_GradeRepository.CreateGrade(Grade))
            {
                ModelState.AddModelError("", $"Error Saving{GradeDto.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


        [HttpPatch("{GradeId:int}", Name = "UpdateGrade")]
        public IActionResult UpdateGrade(int GradeId, [FromBody] UpdateGradeDTO updateGradeDTO)
        {
            if (updateGradeDTO == null || GradeId == null || updateGradeDTO.Id == 0)
            {
                return BadRequest(ModelState);
            }

            var Grade = _mapper.Map<Grade>(updateGradeDTO);

            if (!_GradeRepository.UpdateGrade(Grade))
            {
                ModelState.AddModelError("", $"Error Update {Grade.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{GradeId:int}", Name = "DeleteGrade")]
        public IActionResult DeleteGrade(int GradeId)
        {
            if (!_GradeRepository.ExistGrade(GradeId))
            {
                return NotFound();
            }

            var Grade = _GradeRepository.GetGrade(GradeId);

            if (!_GradeRepository.DeleteGrade(Grade))
            {
                ModelState.AddModelError("", $"Error Delete {GradeId}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
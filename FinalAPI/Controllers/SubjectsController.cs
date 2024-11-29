using FinalAPI.DAL.Entities;
using FinalAPI.Domain.Interfaces;
using FinalAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjectsAsync()
        {
            var subjects = await _subjectService.GetSubjectsAsync();

            if (subjects == null || !subjects.Any())
            {
                return NotFound();
            }
            return Ok(subjects);
        }
    }
}

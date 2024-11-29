﻿using FinalAPI.DAL.Entities;
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

        #region Subject by Student id

        [HttpGet, ActionName("GetSubjectsByStudentId")]
        [Route("GetByStudentId/{id}")] //URL api/states by country/get
        public async Task<ActionResult<Subject>> GetSubjectsByStudentIdAsync(Guid id) // metodo nuevo estara bien ??
        {
            var subjects = await _subjectService.GetSubjectsByStudentIdAsync(id);
            if (subjects == null)
            {
                return NotFound(); //NotFound = Status Code 404 
            }
            return Ok(subjects); //Ok = Status Code 404 
        }

        #endregion



        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]

        public async Task<ActionResult<Subject>> GetSubjectByIdAsync(Guid id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Subject>> CreateSubjectAsync(Subject subject)
        {
            try
            {
                var newSubject = await _subjectService.CreateSubjectAsync(subject);
                if (newSubject == null) return NotFound();
                return Ok(newSubject);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return Conflict(String.Format("{0} ya existe", subject.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Subject>> UpdateSubjectAsync(Subject subject)
        {
            try
            {
                var editedSubject = await _subjectService.UpdateSubjectAsync(subject);
                if (editedSubject == null) return NotFound();
                return Ok(editedSubject);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return Conflict(String.Format("{0} ya existe", subject.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Subject>> DeleteSubjectAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedSubject = await _subjectService.DeleteSubjectAsync(id);
            if (deletedSubject == null) return NotFound();
            return Ok(deletedSubject);

        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using He.BSF.Core.Exceptions;
using He.BSF.Core.Interface;
using He.BSF.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace He.BSF.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private IApplicantRepository _repo;

        public ApplicantController(IApplicantRepository repo)
        {
            _repo = repo;
        }        

        /// <summary>
        /// Retrieving a ApplicantItem using its ApplicantItem Id
        /// </summary>
        /// <remarks>
        /// Retrieves a DocumentItem using its ApplicantITem Id
        /// </remarks>
        /// <param name="applicantId">The Id of the DocumentItem item to be retrieved</param>
        /// <returns>Returns the full DocumentItem document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpGet("{applicantId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Applicant))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetItem(string applicantId)
        {
            try
            {
                var toDo = await _repo.GetByIdAsync(applicantId);
                return Ok(toDo);
            }
            catch (EntityNotFoundException)
            {
                return NotFound(applicantId);
            }
        }

       
        /// <summary>
        /// Creating a new Applicant Document
        /// </summary>
        /// <param name="newApplicantItem"> JSON New Applicant document</param>
        /// <returns>Returns the new Applicant Id </returns>
        /// <returns>Returns 201 Created success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] Applicant newApplicantItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var toDo = await _repo.AddAsync(newApplicantItem);

            return Ok(toDo);
        }


        /// <summary>
        /// Updating Applicant Document
        /// </summary>
        /// <remarks>Updates an existing item </remarks>
        /// <param name="applicantId">Id of an existing TodoItem that needs to be updated</param>
        /// <param name="updatedApplicantItem">JSON TodoItem document to be updated in an existing TodoItem</param>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{applicantId}")]
        public async Task<ActionResult> UpdateItem(string applicantId, [FromBody] Applicant updatedApplicantItem)
        {
            if (updatedApplicantItem.Id != applicantId)
            {
                return BadRequest(updatedApplicantItem.Id);
            }

            try
            {
                if (applicantId == null)
                {
                    return NotFound(applicantId);
                }

                await _repo.UpdateAsync(updatedApplicantItem);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound(applicantId);
            }
        }
    }
}

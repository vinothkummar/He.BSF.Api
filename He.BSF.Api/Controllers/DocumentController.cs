using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using He.BSF.Core.Exceptions;
using He.BSF.Core.Interfaces;
using He.BSF.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace He.BSF.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]    
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentItemRepository _repo;

        public DocumentController(IDocumentItemRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retrieving a TodoItem using its TodoItem Id
        /// </summary>
        /// <remarks>
        /// Retrieves a DocumentItem using its TodoItem Id
        /// </remarks>
        /// <param name="documentId">The Id of the DocumentItem item to be retrieved</param>
        /// <returns>Returns the full DocumentItem document </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpGet("{documentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetItem(string documentId)
        {
            try
            {
                var toDo = await _repo.GetByIdAsync(documentId);
                return Ok(toDo);
            }
            catch (EntityNotFoundException)
            {
                return NotFound(documentId);
            }
        }

        /// <summary>
        /// Creating a new DocumentItem Item
        /// </summary>
        /// <param name="newDocumentItem"> JSON New TodoItem document</param>
        /// <returns>Returns the new DocumentItem Id </returns>
        /// <returns>Returns 201 Created success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] DocumentItem newDocumentItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var toDo = await _repo.AddAsync(newDocumentItem);

            return Ok(toDo);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

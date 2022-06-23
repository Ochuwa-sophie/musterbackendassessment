using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusterBackendAssessment.Services;

namespace MusterBackendAssessment.Controllers
{
    [Route("/")]
    [ApiController]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// Return the matrix as a string in matrix format. Please note that this endpoint does not check the validity of
        /// the content of the file, only its extension and its value.
        /// </summary>
        /// <param name="file">The file to process</param>
        /// <returns>The matrix as a string in matrix format.</returns>
        [AllowAnonymous]
        [HttpPost("echo")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Echo(IFormFile file) 
        {
            try
            {
                if (CheckIfFileIsValid(file))
                {
                    var str = await ReadAsStringAsync(file);
                    return Ok(str);
                }
                else
                {
                    return BadRequest("Invalid file format, please enter a .csv file");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
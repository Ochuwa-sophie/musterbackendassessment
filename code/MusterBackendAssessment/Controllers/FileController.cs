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
    //This class should only 
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
                Matrix matrixClass = new Matrix();
                    matrixClass.CheckIfFileIsValid(file);

                if (matrixClass.CheckIfFileIsValid(file))
                {
                    var str = await Matrix.ReadAsStringAsync(file);
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

        /// <summary>
        /// Return the matrix as a transposed matrix in string format.
        /// </summary>
        /// <param name="file">The file to process</param>
        /// <returns>The transposed matrix in string format.</returns>
        [AllowAnonymous]
        [HttpPost("transpose")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Transpose(IFormFile file) 
        {
            // Matrix fileValid = new Matrix();
            // fileValid.CheckIfFileIsValid(file);
            // var filevalidation = fileValid.CheckIfFileIsValid(file);

            try
            {
                if (filevalidation)
                {
                    var inputString = await Matrix.ReadAsStringAsync(file);
                    // string result;

                    Matrix forParsing = new Matrix();
                 var matrix = forParsing.Parse(inputString
                                        // , out result
                                        );
                    
                    // var transpose = matrix.Transpose();
                    // var result = transpose.ToString();
                        
                        return Ok(matrix);                }
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

        internal bool CheckIfFileIsValid(IFormFile file)
        {
            if (file == null) //Break if file is null
            {
                throw new FileNotFoundException("File cannot be null, please upload a file");
            }
            else
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                return extension == ".csv";
            }

        }




    }
}
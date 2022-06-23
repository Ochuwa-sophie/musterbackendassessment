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

namespace MusterBackendAssessment.Services
{
    public class Matrix{

        /// <summary>
        /// Reads the content of the file into a string variable 
        /// </summary>
        /// <param name="file">The file to be read</param>
        /// <returns>A string whose value is the content of the file</returns>
        public static async Task<string> ReadAsStringAsync( IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return await Task.FromResult((string)null);
                }

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks if the file is not null and has a valid extension
        /// </summary>
        /// <param name="file">The file to be checked </param>
        /// <returns>A boolean for whether the file is valid or otherwise </returns>
        private bool CheckIfFileIsValid(IFormFile file)
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
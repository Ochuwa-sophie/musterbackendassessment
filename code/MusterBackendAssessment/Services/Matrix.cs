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
                        // private int[,] contents;
                        ///<summary>Create a matrix by parsing a string containing comma-separated elements
                        /// on rows separated by newlines</summary>

                        // private Matrix(int[,] contents) {
                        //     this.contents = contents;
                        // }
private string[,] oneLine;
private Matrix(string[,] oneLine)
{
    this.oneLine = oneLine;
}
        public Matrix()
        {
        }

        // public static int[,]
        // {
        //     return contents;
        // }
        public string Parse(string input, out string result)
                        {
                                if (input == null) //Break if file is null
                            {
                                throw new FileNotFoundException("File cannot be null, please upload a file");
                            } 
                            else{
                                string[] oneLine = input.Split(
                                                    Environment.NewLine.ToArray(),StringSplitOptions.RemoveEmptyEntries);

                                                    List<string[]> matrixTranspose = new List<string[]>();
                                                    foreach (string one in oneLine)
                                                    {
                                                      matrixTranspose.Add(one.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                                                        
                                                    }   
                                                     result =  matrixTranspose.ToString();
 
                                                    // contents= matrixTranspose.;
                                                        // var result = matrixTranspose.ToString;
                                                        // return (matrixTranspose);
                                                        return matrixTranspose.ToString();
                                                        // return new int[,] contents(int[,]) {matrixTranspose.ToArray};

                                }
                        }



        /// <summary>
        /// Reads the content of the file into a string variable 
        /// </summary>
        /// <param name="file">The file to be read</param>
        /// <returns>A string whose value is the content of the file</returns>
        public static async Task<string> ReadAsStringAsync( IFormFile file)
        {
                if (file == null || file.Length == 0)   return null;
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    return await reader.ReadToEndAsync();
                }

        }

        /// <summary>
        /// Checks if the file is not null and has a valid extension
        /// </summary>
        /// <param name="file">The file to be checked </param>
        /// <returns>A boolean for whether the file is valid or otherwise </returns>
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
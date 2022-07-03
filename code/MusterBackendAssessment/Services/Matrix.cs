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
    //this class should only handle Numbers and matrix related actions
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
        public Array[,] Parse(string input 
                                        // ,out string result
                                        )
                        {       
                                if (input == null) //Break if file is null, 
                                //change to output from file processing
                            {
                                // 123,456,789
                                //files are on disk, strings are in memory. What is this method responsible for? strings not files.
                                throw new ArgumentNullException ("String cannot be null, ");
                            } 
                            else{
                                string[] oneLine = input.Split(
                                                    Environment.NewLine.ToArray(),StringSplitOptions.RemoveEmptyEntries);

                                                    // List<string[]> matrixTranspose = new List<string[]>();
                                                    string matrixTranspose;
                                                    // string transposeJoin;
                                                    foreach (string one in oneLine)
                                                    {
                                                    //   matrixTranspose.Add(one.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                                                        matrixTranspose = string.Join(",",one, StringSplitOptions.RemoveEmptyEntries);
                                                    // matrixTranspose=transposeJoin; 
                                                        string TransposeJoin = matrixTranspose.ToString() ;


                                                    }   
                                                    //  result =  transposeJoin;
                                                     return (TransposeJoin);
 
                                                    // contents= matrixTranspose.;
                                                        // var result = matrixTranspose.ToString;
                                                        // return (matrixTranspose);
                                                        // return string.Join<matrixTranspose>(",",IEnumerable<matrixTranspose> ) .ToString();
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
    }
    

}
// using System;

// public class Matrix {
//     private Matrix(int[,] contents) {
//         this.Contents = contents;
//     }
//     public int[,] Contents { get; init; }

//     ///<summary>Create a matrix by parsing a string containing comma-separated elements
//     /// on rows separated by newlines</summary>
//     public static Matrix Parse(string input) {    
//         // TODO: instead of hard-coding the matrix,
//         // you need to split the string input into lines,
//         // split each line into tokens (numbers), parse each number
//         // into an integer, and then construct a new matrix using
//         // that set of numbers.
//         return new Matrix(new int[,] { { 1,1}, {2,2} });
//     }

//     public Matrix Transpose() {
//         // TODO: Return a new matrix whose contents
//         // are the transpose of the current matrix.
//         return new Matrix(new int[,] { { 1,1,1}, {2,2,2}, {3,3,3} });
//     }
//     public override string ToString() {
//         return "//todo: return this matrix as a string :)";
//     }
// }
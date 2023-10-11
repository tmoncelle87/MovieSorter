using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
namespace MovieProject
{
    internal class Program
    {
        static void Main(string[] args)

        {//created a list of movies and a file gateway then created the get movies method
            List<Movie> aListOfMovie = new List<Movie>();
            FileGateway aGateway = new FileGateway();
            aListOfMovie = aGateway.GetMovies("C:\\Users\\tmonc\\Documents\\GitHub\\MovieSorter\\MovieProject\\MoviesInputs.txt");
            //this loops ough the list of movies and prints off each movie name and adds a number counter next to it
            
            foreach (var m in aListOfMovie)
            {
              
                Console.WriteLine(m.ToString());
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\tmonc\\Documents\\GitHub\\MovieSorter\\MovieProject\\MovieOutputs.txt"))
            {
                // Loop through each Movie object in the list and write its ToString output to the file
                writer.WriteLine("Number ##" + "       " + "Movie Name");
                foreach (var m in aListOfMovie)
                {
                    string movieString = m.ToString();
                    writer.WriteLine(movieString.ToUpper());
                }
            }
            
            Console.ReadLine();
        }
    }
}

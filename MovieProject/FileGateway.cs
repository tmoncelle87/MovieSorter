using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MovieProject
{
    public class FileGateway
    {
        Movie aMovie;
        //created the get movies method which finds the movie name and splits the lines by a comma
        public List<Movie> GetMovies(string aPath)
        {
            string[] allLines = File.ReadAllText(aPath).Split(',');
            string[] aRow;
            int index = 0;
            int movieCount = 0;
            List<Movie> aListOfMovie = new List<Movie>();
            //this loop finds the movie name and adds it to the listofmovies
            while (index < allLines.Length)
            {
                aMovie = new Movie();
                aRow = allLines[index].Split(',');
                aMovie.MovieName =aRow[0];
                aListOfMovie.Add(aMovie);
                index++;
            }
            //this sorts the list of movies alphabetically
            var sorted = from m in aListOfMovie
                         orderby m.MovieName//, m.MovieCount
                         select m;
            aListOfMovie = sorted.ToList<Movie>();
            //this loops through the movies in a list of movies and increases the movie count number
            foreach (Movie aMovie in aListOfMovie)
            {
                movieCount++;
                aMovie.MovieCount = movieCount;
            }
            return aListOfMovie;
        }
    }
}
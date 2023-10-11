using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MovieProject
{
    public class Movie
    {//creation of variables with gets and sets
        private string movieName = "n/a";
        private int movieCount = 0;
        public string MovieName
        {
            get { return this.movieName; }
            set { this.movieName = value; }
        }
        public int MovieCount
        {
            get { return this.movieCount; }
            set { this.movieCount = value; }
        }//Tostring method that displays movie count next to the movie name
        public override string ToString()
        {
            string msg;
            if (this.MovieCount > 99)
            {
                msg = "Number: " + this.MovieCount + "    " + this.MovieName;
            }
            else if (this.MovieCount > 9)
            {
                msg = "Number: " + this.MovieCount + "     " + this.MovieName;
            }
            else
            {
                msg = "Number: " + this.MovieCount + "      " + this.MovieName;
            }
            return msg;
        }
    }
}

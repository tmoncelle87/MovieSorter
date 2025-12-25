using Microsoft.SqlServer.Server;
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
            int MovieCount =0;
            DateTime DateRan = DateTime.Now;
            bool IsRemoveDuplicates = true;
            bool IsCapitalization = true;
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            List<Movie> aListOfMovie = new List<Movie>();
            FileGateway aGateway = new FileGateway();
            aListOfMovie = aGateway.GetMovies(@"E:\Coding Stuff\Repro\MovieSorter\MovieProject\MoviesInputs.txt");
            //Functions
            string CapitalizeWords(string Input)
            {
                if (string.IsNullOrEmpty(Input))
                    return Input;
                char[] Chars = Input.ToCharArray();
                // Capitalize first character
                if (char.IsLetter(Chars[0]))
                    Chars[0] = char.ToUpper(Chars[0]);
                // Capitalize any character that follows a space
                for (int i = 1; i < Chars.Length; i++)
                {
                    if (Chars[i - 1] == ' ' || (Chars[i - 1] == '-' && char.IsLetter(Chars[i])))
                    {
                        Chars[i] = char.ToUpper(Chars[i]);
                    }
                }

                return new string(Chars);
            }
            //this loops ough the list of movies and prints off each movie name and adds a number counter next to it
            foreach (var m in aListOfMovie)
            {
                Console.WriteLine(m.ToString());
            }
            using (StreamWriter writer = new StreamWriter("E:\\Coding Stuff\\Repro\\MovieSorter\\MovieProject\\MovieOutputs.txt"))
            {
                // Loop through each Movie object in the list and write its ToString output to the file
                writer.WriteLine("--------------------------------------\n" +
                    "Scott's Movie Collection\n" +
                    "Date Ran: " + DateRan.ToString("MM/dd/yyyy") +
                    "\nDuplicate Removal: " + (IsRemoveDuplicates ? "Enabled" : "Disabled") +
                    "\nCapitalization: " + (IsCapitalization ? "Enabled" : "Disabled") +
                    "\n--------------------------------------");
                foreach (var m in aListOfMovie)
                {
                    string title = (m.MovieName ?? "").Trim();
                    // decide whether to write
                    if (!IsRemoveDuplicates || seen.Add(title))
                    {
                        MovieCount++;
                        if (IsCapitalization)
                            title = CapitalizeWords(title);
                        // write your own numbering (001, 002, ...)
                        writer.WriteLine($"{MovieCount:D3}:  {title}");
                    }
                }
                writer.WriteLine("--------------------------------------\n" +
                    "End of Inventory Movie Count: " + MovieCount +
                    "\n--------------------------------------\n");
            }
            Console.ReadLine();
        }
    }
}

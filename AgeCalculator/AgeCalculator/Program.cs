using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your date of birth.");
            var input = Console.ReadLine();
            DateTime dob = DateTime.Parse(input);
            DateTime currentTime = DateTime.Now;
            var age = Math.Floor((currentTime.Subtract(dob).TotalDays)/365);
            var ageHours = Math.Floor((currentTime.Subtract(dob).TotalHours));
            var ageMinutes = Math.Floor((currentTime.Subtract(dob).TotalMinutes));
            var ageSeconds = Math.Floor((currentTime.Subtract(dob).TotalSeconds));
            var ageMilliSeconds = Math.Floor((currentTime.Subtract(dob).TotalMilliseconds));
            Console.WriteLine("You are " + age + " years old.");
            Console.WriteLine("You are " + ageHours + " hours old.");
            Console.WriteLine("You are " + ageMinutes + " minutes old.");
            Console.WriteLine("You are " + ageSeconds + " seconds old.");
            Console.WriteLine("You are " + ageMilliSeconds + " milliseconds old.");

            Console.ReadLine();
        }
    }
}

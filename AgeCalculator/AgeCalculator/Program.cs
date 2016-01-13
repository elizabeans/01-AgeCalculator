using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCalculator
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static DateTime dob;
        private static double daysInYear = 365.25;


        static void Main(string[] args)
        {
            try
            {
                //Ask for date of birth and parse into DateTime
                Console.WriteLine("What is your birthday? (Enter date in format MM/DD/YYYY):");
                var input = Console.ReadLine();
                dob = DateTime.Parse(input);

                //Timer
                aTimer = new System.Timers.Timer();
                aTimer.Interval = 1000;
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;

                //Stop timer
                Console.ReadLine();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please restart program and enter a valid date of birth.");
               
            }
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Calculate how old the user is 
            DateTime currentTime = DateTime.Now;

            var age = currentTime - dob;
            var ageSeconds = age.TotalSeconds;
            var years = Math.Floor(ageSeconds / 31557600);
            var weeks = Math.Floor( (ageSeconds % 31557600) / 604800);
            var days = Math.Floor(((ageSeconds % 31557600) % 604800) / 86400);
            var hours = Math.Floor((((ageSeconds % 31557600) % 604800) % 86400/3600));
            var minutes = Math.Floor(((((ageSeconds % 31557600) % 604800) % 86400) % 3600) / 60);
            var seconds = Math.Floor(((((ageSeconds % 31557600) % 604800) % 86400) % 3600) % 60);
            var milliseconds = Math.Floor(((((ageSeconds % 31557600) % 604800) % 86400) % 3600) % 60 * 100);
            // Tell user how old they are using different times 
            Console.Clear();

            
            Console.WriteLine("You are " + years + " years, " + weeks + " weeks, " + days + " days, " + hours + 
                " hours, " + minutes + " minutes, " + seconds + " seconds, and " + milliseconds + " milliseconds old." );
            Console.WriteLine("Press the enter key to exit the program at any time");
        }
    }
}

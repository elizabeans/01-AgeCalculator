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
            var ageYears = Math.Floor((currentTime.Subtract(dob).TotalDays) / 365.25);
            var ageMonths = Math.Floor((currentTime.Subtract(dob).TotalDays)%365.25/30);
            var ageWeeks = Math.Floor((currentTime.Subtract(dob).TotalDays)%365.25%30/7);
            var ageDays = Math.Floor((currentTime.Subtract(dob).TotalDays) % 365.25 % 30 % 7);
            var ageHours = Math.Floor((currentTime.Subtract(dob).TotalDays) % 365.25 % 30 % 7 / 24);
            //var ageMinutes
            //var ageSeconds
            //var ageMilliSeconds
            

            // Tell user how old they are using different times 
            Console.Clear();
            Console.WriteLine("You are " + ageYears + " years, " + ageMonths + " months, " + ageWeeks + " weeks, " + ageDays +
                " days old.");

            /*Commented out because didn't do math right initially and will have to fix
            
            + ageHours + " hours, " + ageMinutes + " minutes, " + ageSeconds + 
            " seconds, and " + ageMilliSeconds + " milliseconds old.");*/
            Console.WriteLine("Press the enter key to exit the program at any time");
        }
    }
}

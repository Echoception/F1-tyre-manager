using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace F1_Tyre
{
    internal class Alarm
    {
        public DateTime AlarmTime { get; set; }
        public TimeSpan Duration { get; set; }



        public void Timer()
        {
            int minutes = 0;
            int seconds = 0;

            Console.Write("Enter minutes: ");
            Int32.TryParse(Console.ReadLine(), out minutes);
            Console.Write("Enter seconds: ");
            Int32.TryParse(Console.ReadLine(), out seconds);

            Console.WriteLine("Press 'Enter' to start");
            Console.ReadLine();

            Duration = new TimeSpan(0, minutes, seconds);
            AlarmTime = DateTime.Now + Duration;
            Console.WriteLine(Duration);
            Console.WriteLine($"At: " + AlarmTime.ToShortTimeString());

            do
            {

            } while (AlarmTime.CompareTo(DateTime.Now) >= 0);

            for (int i = 0; i < 10; i++)
            {
                Console.Beep();
            }

        }

    }
}

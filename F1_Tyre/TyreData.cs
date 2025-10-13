using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Tyre
{
    internal class TyreData()
    {

        private decimal SoftBaseTime { get; set; } = 0;
        private decimal MediumBaseTime { get; set; } = 0;
        private decimal HardBaseTime { get; set; } = 0;
        private decimal SoftDegTime { get; set; } = 0;
        private decimal MediumDegTime { get; set; } = 0;
        private decimal HardDegTime { get; set; } = 0;
        //-----------------------------------------------------------------
        public decimal SoftTime { get; set; } = 0; 
        public decimal MediumTime { get; set; } = 0;
        public decimal HardTime { get; set; } = 0;
        public decimal SoftStintTime { get; set; } = 0;
        public decimal MediumStintTime { get; set; } = 0;
        public decimal HardStintTime { get; set; } = 0;
        public decimal SoftAverageLapTime { get; set; } = 0;
        public decimal MediumAverageLapTime { get; set; } = 0;
        public decimal HardAverageLapTime { get; set; } = 0;
        public int Laps { get; set; } = 0;



        public decimal GetValidDecimal()
        {
            string? userInput = "";
            decimal validDecimal = 0;
            bool validInput = false;

            do
            {
                userInput = Console.ReadLine();
                if (decimal.TryParse(userInput, out validDecimal))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Enter a numerical value");
                    validInput = false;
                }
            } while (validInput != true);

            return validDecimal;
        }

        public int GetValidInt()
        {
            string? userInput = "";
            int validInt = 0;
            bool validInput = false;

            do
            {
                userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out validInt))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Enter a whole number value");
                    validInput = false;
                }
            } while (validInput != true);

            return validInt;
        }


        public void GetData()
        {
            Console.Write("\nInput the expected time (in seconds) for Soft tyres: ");
            SoftBaseTime = GetValidDecimal();
            Console.Write("\nEnter the expected lap time (in seconds) for Medium tyres: ");
            MediumBaseTime = GetValidDecimal();
            Console.Write("\nEnter the expected lap time (in seconds) for Hard tyres: ");
            HardBaseTime = GetValidDecimal();
            Console.Write("\nEnter the expected deg time for Soft Tyres: ");
            SoftDegTime = GetValidDecimal();
            Console.Write("\nEnter the expected deg time for Medium tyres: ");
            MediumDegTime = GetValidDecimal();
            Console.Write("\nEnter the expected deg time for Hard tyres: ");
            HardDegTime = GetValidDecimal();
            Console.Clear();
        }

        public void CompareSoftAndMedium()
        {
            SoftTime = SoftBaseTime;
            MediumTime = MediumBaseTime;
            SoftStintTime = 0;
            MediumStintTime = 0;

            Console.WriteLine("________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Laps\t\tSoft\t\tMedium\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 1; SoftTime <= MediumTime; i++)
            {
                Laps = i;
                

                Console.WriteLine($"{Laps}\t\t{decimal.Round(SoftTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(MediumTime, 3, MidpointRounding.AwayFromZero)}");

                SoftStintTime += SoftTime;
                MediumStintTime += MediumTime;
                SoftTime += SoftDegTime;
                MediumTime += MediumDegTime;

                if (i >= 100)
                {
                    Console.WriteLine("\n Laps has exceeded 100, input error detected");
                    Console.WriteLine("Re-input times to fix");
                    break;
                }
            }

            SoftAverageLapTime = SoftStintTime / Laps;
            MediumAverageLapTime = MediumStintTime / Laps;
            SoftStintTime /= 60;
            MediumStintTime /= 60;

            Console.WriteLine("\n________________________________________________________");
            Console.WriteLine($"\nStint (mins)\t{decimal.Round(SoftStintTime, 2, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(MediumStintTime, 2, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"\nAverage\t\t{decimal.Round(SoftAverageLapTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(MediumAverageLapTime, 3, MidpointRounding.AwayFromZero)}");
            Console.WriteLine("\n________________________________________________________");


        }

        public void CompareSoftAndHard()
        {
            SoftTime = SoftBaseTime;
            HardTime = HardBaseTime;
            SoftStintTime = 0;
            HardStintTime = 0;

            Console.WriteLine("________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Laps\t\tSoft\t\tHard\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 1; SoftTime <= HardTime; i++)
            {
                Laps = i;
                SoftStintTime += SoftTime;
                HardStintTime += HardTime;

                Console.WriteLine($"{Laps}\t\t{decimal.Round(SoftTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardTime, 3, MidpointRounding.AwayFromZero)}");

                SoftTime += SoftDegTime;
                HardTime += HardDegTime;

                if (i >= 100)
                {
                    Console.WriteLine("\n Laps has exceeded 100, input error detected");
                    Console.WriteLine("Re-input times to fix");
                    break;
                }
            }

            SoftAverageLapTime = SoftStintTime / Laps;
            HardAverageLapTime = HardStintTime / Laps;
            SoftStintTime /= 60;
            HardStintTime /= 60;

            Console.WriteLine("\n________________________________________________________");
            Console.WriteLine($"\nStint (mins)\t{decimal.Round(SoftStintTime, 2, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardStintTime, 2, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"\nAverage\t\t{decimal.Round(SoftAverageLapTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardAverageLapTime, 3, MidpointRounding.AwayFromZero)}");
            Console.WriteLine("\n________________________________________________________");
        }

        public void CompareMediumAndHard()
        {
            MediumTime = MediumBaseTime;
            HardTime = HardBaseTime;
            MediumStintTime = 0;
            HardStintTime = 0;

            Console.WriteLine("________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Laps\t\tMedium\t\tHard\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 1; MediumTime <= HardTime; i++)
            {
                Laps = i;
                MediumStintTime += MediumTime;
                HardStintTime += HardTime;

                Console.WriteLine($"{Laps}\t\t{decimal.Round(MediumTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardTime, 3, MidpointRounding.AwayFromZero)}");

                MediumTime += MediumDegTime;
                HardTime += HardDegTime;

                if (i >= 100)
                {
                    Console.WriteLine("\n Laps has exceeded 100, input error detected");
                    Console.WriteLine("Re-input times to fix");
                    break;
                }
            }

            MediumAverageLapTime = MediumStintTime / Laps;
            HardAverageLapTime = HardStintTime / Laps;
            MediumStintTime /= 60;
            HardStintTime /= 60;

            Console.WriteLine("\n________________________________________________________");
            Console.WriteLine($"\nStint (mins)\t{decimal.Round(MediumStintTime, 2, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardStintTime, 2, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"\nAverage\t\t{decimal.Round(MediumAverageLapTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardAverageLapTime, 3, MidpointRounding.AwayFromZero)}");
            Console.WriteLine("\n________________________________________________________");
        }


        public void ProjectLaps()  //  ASK FOR LAPS IN OR OUT?
        {
            Console.WriteLine("Enter how many laps to project: ");
            Laps = GetValidInt();

            SoftTime = SoftBaseTime;
            MediumTime = MediumBaseTime;
            HardTime = HardBaseTime;
            SoftStintTime = 0;
            MediumStintTime = 0;
            HardStintTime = 0;

            Console.WriteLine("________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Laps\t\tSoft\t\tMedium\t\tHard\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 1; i <= Laps; i++)
            {
                SoftStintTime += SoftTime;
                MediumStintTime += MediumTime;
                HardStintTime += HardTime;

                Console.WriteLine($"{i}\t\t{decimal.Round(SoftTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(MediumTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardTime, 3, MidpointRounding.AwayFromZero)}");
                
                SoftTime += SoftDegTime;
                MediumTime += MediumDegTime;
                HardTime += HardDegTime;

            }

            SoftAverageLapTime = SoftStintTime / Laps;
            MediumAverageLapTime = MediumStintTime / Laps;
            HardAverageLapTime = HardStintTime / Laps;
            SoftStintTime /= 60;
            MediumStintTime /= 60;
            HardStintTime /= 60;

            Console.WriteLine("\n________________________________________________________");
            Console.WriteLine($"\nStint (mins)\t{decimal.Round(SoftStintTime, 2, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(MediumStintTime, 2, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardStintTime, 2, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"\nAverage\t\t{decimal.Round(SoftAverageLapTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(MediumAverageLapTime, 3, MidpointRounding.AwayFromZero)}\t\t{decimal.Round(HardAverageLapTime, 3, MidpointRounding.AwayFromZero)}");
            Console.WriteLine("\n________________________________________________________");
        }




    }
}

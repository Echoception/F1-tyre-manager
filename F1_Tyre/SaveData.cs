using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ExceptionServices;

namespace F1_Tyre
{  /*  save five set-up options(decimals) for 24 tracks  */
    internal class SaveData(TyreData tyreData)
    {

        List<string> tracklist = ["sakhir, bahrain",   
            "jeddah, saudi arabia",
            "melbourne, australia",
            "suzuka, japan",
            "shanghai, china",
            "miami, florida",
            "imola (emilia-romagna)",
            "monte carlo, monaco",
            "montreal, canada",
            "catalunya, spain",
            "red bull ring(spielberg), austria",
            "silverstone, great britain, uk",
            "hungaroring, hungary",
            "spa-francorchamps, belgium",
            "zandvoort, netherlands",
            "monza",
            "baku, azerbaijan",
            "marina bay, singapore",
            "circuit of the americas(cota)  austin, texas",
            "mexico city, mexico",
            "interlagos, brazil",
            "las vegas, nevada",
            "losail, qatar",
            "yas marina, abu dhabi, uae"];   



        public string GetValidString()
        {
            string userInput = Console.ReadLine();
            
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Enter a valid string");
                GetValidString();
            }

            return userInput;
        }

        public bool GetValidTrack(string track)
        {
            bool isValid = false;

            for(int i = 0; i < tracklist.Count; i ++)
            {
                if (tracklist[i].Contains(track.ToLower()))
                {
                    isValid = true;
                    break;
                }
            }

            if(isValid == false)
            {
                Console.WriteLine("Enter a valid track");
            }

            return isValid;
        }

        public void SaveSetUpData()
        {
            bool validTrack = false;
            decimal[] setUpValues = new decimal[5];
            string userInput = "";

            do
            {
                Console.WriteLine("Enter the desired track: ");
                userInput = GetValidString();
                validTrack = GetValidTrack(userInput);
            } while (validTrack == false);


            Console.WriteLine("\nEnter the set-up values:\n");
            Console.Write("Front Wing Angle: ");
            setUpValues[0] = tyreData.GetValidDecimal();
            Console.Write("Rear Wing Angle: ");
            setUpValues[1] = tyreData.GetValidDecimal();
            Console.Write("Anti-Roll Distribution: ");
            setUpValues[2] = tyreData.GetValidDecimal();
            Console.Write("Tyre Camber: ");
            setUpValues[3] = tyreData.GetValidDecimal();
            Console.Write("Toe-Out: ");
            setUpValues[4] = tyreData.GetValidDecimal();

            string line = "";
            decimal isNumber = 0;


            StringBuilder sbText = new StringBuilder();

            using (var reader = new StreamReader("SetUpValues.txt"))
            {

                while ((line = reader.ReadLine()) != null)
                {

                    if (line.ToLower().Contains(userInput.ToLower()))
                    {
                        sbText.AppendLine(line);
                        foreach (decimal value in setUpValues)
                        {
                            sbText.AppendLine(value.ToString());
                        }

                        do
                        {
                            line = reader.ReadLine(); // Skip the next five as they are the old values
                        } while (Decimal.TryParse(line, out isNumber));

                        sbText.AppendLine(line);
                    }
                    else
                    {

                        sbText.AppendLine(line);
                    }
                    
                    //sbText.AppendLine(reader.ReadLine()); <--- THIS FUCKED ME FOR HOURS
                }
                Console.WriteLine("\nSAVED\n");
                Console.ReadKey();
                Console.Clear();
            }

            using (var writer = new StreamWriter("SetUpValues.txt"))
            {
                writer.Write(sbText.ToString());
            }
            sbText.Clear();

        }


        public void LoadSetUpData()
        {
            bool validTrack = false;

            using (var reader = new StreamReader("SetUpValues.txt"))
            {
                string line = "";
                string userInput = "";
                decimal[] setUpValues = new decimal[5];
                string trackName = "";

                do
                {
                    Console.WriteLine("Enter the desired track: ");
                    userInput = GetValidString();
                    validTrack = GetValidTrack(userInput.ToLower());
                } while (validTrack == false);

                while ((line = reader.ReadLine().ToLower()) != null)
                {
                    if (line.Contains(userInput.ToLower()))
                    {
                        trackName = line; 

                            for(int i = 0; i < 5; i++)
                            {
                                line = reader.ReadLine();
                                Decimal.TryParse(line, out setUpValues[i]);

                            }
                            break;

                    }
                }

                Console.WriteLine("");
                Console.WriteLine(trackName);
                foreach (decimal value in setUpValues)
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine("");
            }

        }

    }
}

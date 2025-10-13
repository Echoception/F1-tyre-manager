using System.ComponentModel.Design;
using System.IO;

namespace F1_Tyre
{
    internal class Program
    {
        //Program that calculates lap times on f1 manager
        /*take inputs for 3 lap times and 3 deg times to calculate from - add save set-up data? ( Front wing angle, Rear wing angle, Anti-roll Distribution, Tyre camber, Toe-out )
         */

        static void Main(string[] args)
        {

            int menu = 99;
            bool validInput = false;
            string? readResult = "";
            TyreData tyreData = new TyreData();
            SaveData saveData = new SaveData(tyreData);

            tyreData.GetData();
            
            do
            {

                //Console.WriteLine("\n________________________________________________________\n");
                Console.WriteLine("[1] - Compare Soft and Medium tyres");
                Console.WriteLine("[2] - Compare Soft and Hard tyres");
                Console.WriteLine("[3] - Compare Medium and Hard tyres");
                Console.WriteLine("[4] - Project XX laps");
                Console.WriteLine("[5] - Clear console");
                Console.WriteLine("[6] - Re-input times");
                Console.WriteLine("[7] - Load Set-Up");
                Console.WriteLine("[8] - Save Set-Up");
                Console.WriteLine("[0] - EXIT");

                menu = tyreData.GetValidInt();

                switch (menu)
                {
                    case 0:
                        continue;
                        break;

                    case 1:
                        tyreData.CompareSoftAndMedium();
                        break;

                    case 2:
                        tyreData.CompareSoftAndHard();
                        break;

                    case 3:
                        tyreData.CompareMediumAndHard();
                        break;

                    case 4:
                        tyreData.ProjectLaps();
                        break;

                    case 5:
                        Console.Clear();
                        break;

                    case 6:
                        tyreData.GetData();
                        break;

                    case 7:
                        saveData.LoadSetUpData();
                        break;

                    case 8:
                        saveData.SaveSetUpData();
                        break;

                    default:
                        Console.WriteLine("Pick an option from the menu");
                        break;
                }


            } while (menu != 0);


        }


    }

}

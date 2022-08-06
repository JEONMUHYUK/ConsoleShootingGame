using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptShootingGame
{
    internal class StartScene
    {
        public void Start()
        {

            Console.Title = "Prompt RPG";
            RunMainMenu();


        }

        private void RunMainMenu()
        {
            string prompt = @"


                           ___                                      _             
                          / _ \  _ __    ___    _ __ ___    _ __   | |_           
                         / /_)/ | '__|  / _ \  | '_ ` _ \  | '_ \  | __|          
                        / ___/  | |    | (_) | | | | | | | | |_) | | |_           
                        \/      |_|     \___/  |_| |_| |_| | .__/   \__|          
                                                           |_|                    
                                 __   _                       _     _                 
                                / _\ | |__     ___     ___   | |_  (_)  _ __     __ _ 
                                \ \  | '_ \   / _ \   / _ \  | __| | | | '_ \   / _` |
                                _\ \ | | | | | (_) | | (_) | | |_  | | | | | | | (_| |
                                \__/ |_| |_|  \___/   \___/   \__| |_| |_| |_|  \__, |
                                                                                |___/ 
                                                          ___                                     
                                                         / _ \   __ _   _ __ ___     ___          
                                                        / /_\/  / _` | | '_ ` _ \   / _ \         
                                                       / /_\\  | (_| | | | | | | | |  __/         
                                                       \____/   \__,_| |_| |_| |_|  \___|         
                                                           


";            // 프롬프트 값
            string[] options = { "Play", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.Beep(630, 300);
                    RunFirstChoice();
                    break;
                case 1:
                    Console.Beep(630, 300);
                    ExitGame();
                    break;
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("\nPressed any Key to exit....");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void RunFirstChoice()
        {
            Console.Clear();
            return;
        }
    }
}

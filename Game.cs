using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int statBoost;
    }

    class Game
    {

        bool _gameOver = false;
        Player _player1 = new Player(50, 50, "Jeff");
        Player _player2 = new Player(150, 20, "Chris");
        Item longsword;
        Item dagger;

        //Allows the program to get inout from the player.
        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.Write("> ");

            input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }

            }
        }

        public void CreateCharacter(Player player)
        {
            Console.WriteLine("What is your name?");
            string _name = Console.ReadLine();
            player = new Player(100, 10, _name);
        }

        //Intializes item values
        public void InitalizeItems()
        {
            longsword.statBoost = 20;
            dagger.statBoost = 10;
        }

        public void SelectItems()
        {
            char input = ' ';
            GetInput(out input, "Longsword", "Dagger", "Welcome player one, please choose a weapon.");
            if (input == '1')
            {
                _player1.EquipWeapon(longsword);
            }
            else if (input == '2')
            {
                _player1.EquipWeapon(dagger);
            }
            Console.WriteLine("\nPlayer 1");
            _player1.PrintStats();


            GetInput(out input, "Longsword", "Dagger", "Welcome player two, please choose a weapon.");
            if (input == '1')
            {
                _player2.EquipWeapon(longsword);
            }
            else if (input == '2')
            {
                _player2.EquipWeapon(dagger);
            }
        }

        public void BattleLoop()
        {
            Console.WriteLine("Now GO!");

            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                Console.Clear();
                _player1.PrintStats();
                _player2.PrintStats();

                char input = ' ';
                GetInput(out input, "Attack", "NO!", "Your turn Player 1");
                if (input == '1')
                {
                    _player1.Attack(_player2);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else if (input == '2')
                {
                    Console.WriteLine("NOOOOOOOOOOOOOOOOOOOOOOOOOOOO!");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }

                Console.Clear();
                _player1.PrintStats();
                _player2.PrintStats();

                GetInput(out input, "Attack", "STOP!", "Your turn Player 2");
                if (input == '1')
                {
                    _player2.Attack(_player1);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else if (input == '2')
                {
                    Console.WriteLine("STOOOOOOOOOOOOOOOOOOOOOOOOP!");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            if (_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 Wins!!!!!!!!!");
                Console.WriteLine("Press any key to continue.");
            }
            else
            {
                Console.WriteLine("Player 2 Wins!!!!!!!!!");
                Console.WriteLine("Press any key to continue.");
            }
            _gameOver = true;
        }

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            InitalizeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            CreateCharacter(_player1);
            CreateCharacter(_player2);
            BattleLoop();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}

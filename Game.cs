using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

    struct Item
    {
        public int statBoost;
    }

    class Game
    {

        bool _gameOver = false;
        Player _player1;
        Player _player2;
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

        //Initializes the player values
        public void InitializePlayer()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
        }

        //Intializes item values
        public void InitalizeItems()
        {
            longsword.statBoost = 20;
            dagger.statBoost = 10;
        }

        public void EquipItems()
        {
            char input = ' ';
            GetInput(out input, "Longsword", "Dagger", "Welcome player one, please choose a weapon.");
            if (input == '1')
            {
                _player1.damage = longsword.statBoost;
            }
            else if (input == '2')
            {
                _player1.damage = dagger.statBoost;
            }
            Console.WriteLine("\nPlayer 1");
            PrintStats(_player1);


            GetInput(out input, "Longsword", "Dagger", "Welcome player two, please choose a weapon.");
            if (input == '1')
            {
                _player2.damage = longsword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage = dagger.statBoost;
            }
        }

        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }

        public void BattleLoop()
        {
            Console.WriteLine("Now GO!");

            while (_player1.health > 0 && _player2.health > 0)
            {
                Console.Clear();
                Console.WriteLine("Player1");
                PrintStats(_player1);
                Console.WriteLine("\nPlayer2");
                PrintStats(_player2);

                char input = ' ';
                GetInput(out input, "Attack", "NO!", "Your turn Player 1");
                if (input == '1')
                {
                    _player2.health -= _player1.damage;
                    Console.WriteLine("Player 1 did " + _player1.damage + " to Player 2.");
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
                Console.WriteLine("Player1");
                PrintStats(_player1);
                Console.WriteLine("\nPlayer2");
                PrintStats(_player2);

                GetInput(out input, "Attack", "STOP!", "Your turn Player 2");
                if (input == '1')
                {
                    _player1.health -= _player2.damage;
                    Console.WriteLine("Player 2 did " + _player2.damage + " to Player 1.");
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
            if (_player1.health > 0)
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
            InitializePlayer();
            InitalizeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            EquipItems();
            BattleLoop();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}

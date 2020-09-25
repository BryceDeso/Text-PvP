using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    //Create a turn based PvP game. It should have a battle loop where both players
    //must fight until one is dead. The game should allow players to upgrade their stats
    //using items. Both players and items should be defined as structs. 


    struct Item
    {
        public string name;
        public int statBoost;
    }


    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossbow;
        private Item _cherrybomb;
        private Item _mace;

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

        public void InitializeItems()
        {
            _longSword.name = "Longsword";
            _longSword.statBoost = 15;
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _bow.name = "Bow";
            _bow.statBoost = 12;
            _cherrybomb.name = "Cherrybomb";
            _cherrybomb.statBoost = 24;
            _crossbow.name = "Crossbow";
            _crossbow.statBoost = 34;
            _mace.name = " Mace";
            _mace.statBoost = 25;
        }

        //Displays two options to the player. Outputs the choice of the two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        //Equip items to both players in the beginning of the game
        public void SelectLoadout(Player player)
        {
            Console.Clear();
            //Displays Loadout 1 to player
            Console.WriteLine("Loadout 1");
            Console.WriteLine(_longSword.name);
            Console.WriteLine(_dagger.name);
            Console.WriteLine(_bow.name);

            //Displays Loadout 2 to player
            Console.WriteLine("\nLoadout 2");
            Console.WriteLine(_mace.name);
            Console.WriteLine(_crossbow.name);
            Console.WriteLine(_cherrybomb.name);

            //Get input for player one
            char input;
            GetInput(out input, "Loadout1", "Loadout2", "Welcome! Please choose a loadout.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
                player.AddItemToInventory(_dagger, 1);
                player.AddItemToInventory(_bow, 2);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_mace, 0);
                player.AddItemToInventory(_crossbow, 1);
                player.AddItemToInventory(_cherrybomb, 2);
            }
        }

        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            SelectLoadout(player);
            return player;
        }

        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void SwitchWeapon(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + " \n Damage: " + inventory[i].statBoost);
            }
            Console.WriteLine("> ");
            input = Console.ReadKey().KeyChar;

            switch(input)
            {
                case '1' :
                    {
                        Console.WriteLine("You've equpped " + inventory[0].name);
                        Console.WriteLine("Base damage increased by " + inventory[0].statBoost);
                        player.EquipItem(0);
                        break;
                    }
                case '2' :
                    {
                        Console.WriteLine("You've equpped " + inventory[1].name);
                        Console.WriteLine("Base damage increased by " + inventory[1].statBoost);
                        player.EquipItem(1);
                        break;
                    }
                case '3' :
                    {
                        Console.WriteLine("You've equpped " + inventory[2].name);
                        Console.WriteLine("Base damage increased by " + inventory[2].statBoost);
                        player.EquipItem(2);
                        break;
                    }
                default :
                    {
                        Console.WriteLine("You accidently dropped your weapon! \nUnfortunate...");
                        player.UnEquipItem();
                        break;
                    }
            }           
        }

        public void StartBattle()
        {
            ClearScreen();
            Console.WriteLine("Now GO!");

            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //print player stats to console
                Console.WriteLine("Player1");
                _player1.PrintStats();
                Console.WriteLine("Player2");
                _player2.PrintStats();
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "Change weapon", "Your turn Player 1");

                if (input == '1')
                {
                    float damageTaken = _player1.Attack(_player2);
                    Console.WriteLine(_player1.GetName() + " did " + damageTaken + " damage!");
                    damageTaken = _player1Partner.Attack(_player2);
                    Console.WriteLine(_player1Partner.GetName() + " did " + damageTaken + " damage!");
                }
                else
                {
                    float damageTaken = _player2.Attack(_player1);
                    Console.WriteLine(_player2.GetName() + " did " + damageTaken + " damage!");
                    damageTaken = _player2Partner.Attack(_player1);
                    Console.WriteLine(_player2Partner.GetName() + " did " + damageTaken + " damage!");
                }

                GetInput(out input, "Attack", "Change weapon", "Your turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    SwitchWeapon(_player2);
                }
                Console.Clear();
            }
            if (_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 wins!!1!1!!11!11?");
            }
            else
            {
                Console.WriteLine("Player 2 wins??????????");
            }
            ClearScreen();
            _gameOver = true;
        }


        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
            _player1Partner = new Wizard(120, "Wizard Lizard", 20, 100);
            _player2Partner = new Wizard(120, "Hairy Wizard 101", 20, 100);
        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}

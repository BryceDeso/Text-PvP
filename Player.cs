using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _basedamage;
        private Item[] _inventory;
        private Item _currentweapon;
        private Item _hands;

        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _basedamage = 10;
            _hands.name = "Hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
        {
            _name = nameVal;
            _health = healthVal;
            _basedamage = damageVal;
            _hands.name = "Hands";
            _hands.statBoost = 0;
            _inventory = new Item[inventorySize];
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentweapon = _inventory[itemIndex];
            }
        }

        public bool Contains(int ItemIndex)
        {
            if (ItemIndex > 0 && ItemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public string GetName()
        {
            return _name;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void UnEquipItem()
        {
            _currentweapon = _hands;
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _basedamage + _currentweapon.statBoost;
            enemy.TakeDamage(totalDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _basedamage);
        }

        private void TakeDamage(int damageVal)
        {
            if (GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!!!");
        }
    }
}

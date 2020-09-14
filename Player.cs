using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _damage;

        public Player()
        {
            _health = 100;
            _damage = 10;
        }

        public Player(int healthVal, int damageVal, string nameVal)
        {
            _name = nameVal;
            _damage = damageVal;
            _health = healthVal;
        }

        public void EquipWeapon(Item weapon)
        {
            _damage += weapon.statBoost;
        }

        public void PrintStats()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void Attack(Player enemy)
        {
            enemy.TakeDamage(_damage);
        }

        private void TakeDamage(int damageVal)
        {
            if(GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + "took " + damageVal + " damage!");
        }

    }
}

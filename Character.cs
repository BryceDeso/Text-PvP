using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        private string _name;
        protected float _damage;

        public Character()
        {
            _health = 100;
            _name = "Hero";
            _damage = 10;
        }

        public Character(float healthVal, string nameVal, float damageVal)
        {
            _health = healthVal;
            _damage = damageVal;
            _name = nameVal;
        }

        public virtual float Attack(Character enemy)
        {
            float damageTaken = enemy.TakeDamage(_damage);
            return damageTaken;
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
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

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0 )
            {
                _health = 0;
            }
            return damageVal;
        }
    }
}

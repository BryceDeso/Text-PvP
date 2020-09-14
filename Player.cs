using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        public Player(int healthVal, int damageVal)
        {
            damage = damageVal;
            health = healthVal;
        }

        public Player()
        {
            health = 100;
            damage = 10;
        }
        public int health;
        public int damage;
    }
}

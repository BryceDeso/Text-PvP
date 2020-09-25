using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentweapon;
        private Item _hands;

        public Player()
        {
            _inventory = new Item[3];
            _hands.name = "Hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, float healthVal, float damageVal, int inventorySize)
            : base(healthVal, nameVal, damageVal)
        {
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

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void UnEquipItem()
        {
            _currentweapon = _hands;
        }

        public override float Attack(Character enemy)
        {
            float totalDamage = _damage + _currentweapon.statBoost;
            return enemy.TakeDamage(totalDamage);
        }
    }
}

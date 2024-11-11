using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace ZombieShooter.InventorySystem
{
    public class Inventory : ICollection<Item>, IInventory
    {
        private List<Item> _items;

        private Subject<Item> OnAdd = new();
        private Subject<Item> OnRemove = new();

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        ISubject<Item> IInventory.OnAdd => OnAdd;

        ISubject<Item> IInventory.OnRemove => OnRemove;

        public Inventory()
        {
            _items = new();
        }

        public void Add(Item item)
        {
            _items.Add(item);

            Debug.Log($"added new itwm to inventory {item.ToString()}");

            OnAdd?.OnNext(item);
        }

        public void Add(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Item item)
        {
            return _items.Contains(item);
        }

        public bool Contains(string guid)
        {
            return _items.Any(x => x.GUID == guid || x.ReferenceGUID == guid);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool Remove(Item item)
        {
            bool isRemoved = _items.Remove(item);

            if (isRemoved)
            {
                Debug.Log($"removed itwm from inventory {item.ToString()}");
                OnRemove?.OnNext(item);
            }
            return isRemoved;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

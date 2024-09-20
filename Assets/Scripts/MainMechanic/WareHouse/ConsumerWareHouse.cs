using System;
using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using UnityEngine;

namespace MainMechanic.WareHouse
{
    public class ConsumerWareHouse : MonoBehaviour
    {
        public int _storageСapacity;
        public List<IConsumableResource> _consumableRes;
        private bool isTakingResourcesFinished = true;
        public static Action onResurceTakes;
        private void Awake()
        {
            _consumableRes = new List<IConsumableResource>();
        }
        private IEnumerator TakingResourcesFromPlayer(Inventory inventory,int lasItem)
        {
            isTakingResourcesFinished = false;
            CollectResources(inventory, lasItem);
            yield return new WaitForSeconds(1f);
            isTakingResourcesFinished = true;
        }

        private void CollectResources(Inventory inventory, int lastItem)
        {
            if (inventory._resourcesInInventory.Count > 0)
            {
                var resource = inventory._resourcesInInventory[lastItem];
                _consumableRes.Add(resource);
                inventory._resourcesInInventory.RemoveAt(lastItem);
                onResurceTakes?.Invoke();
            }
        }
        

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                bool isHaveEnoughSpace = _consumableRes.Count < _storageСapacity;
                int lastItem = inventory._resourcesInInventory.Count - 1;
                if (isHaveEnoughSpace && isTakingResourcesFinished)
                {
                    StartCoroutine(TakingResourcesFromPlayer(inventory, lastItem));
                }
                else if (!isHaveEnoughSpace) print($"WareHouse is full!");
                else print($"Wait For Taking!");
            }
        }
    }
}
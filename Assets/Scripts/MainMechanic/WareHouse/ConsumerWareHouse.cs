using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using UnityEngine;

namespace MainMechanic.WareHouse
{
    public class ConsumerWareHouse : MonoBehaviour
    {
        public int _storageСapacity;
        private List<IConsumableResource> _consumableRes;
        private bool isTakingResourcesFinished = true;
        private void Awake()
        {
            _consumableRes = new List<IConsumableResource>();
        }

       
        private IEnumerator TakingResourcesFromPlayer(Inventory inventory,int index)
        {
            isTakingResourcesFinished = false;
            CollectResources(inventory, index);
            yield return new WaitForSeconds(1f);
            isTakingResourcesFinished = true;
        }

        private void CollectResources(Inventory inventory, int index)
        {
            var resource = inventory._resourcesInInventory[index];
            _consumableRes.Add(resource);
        }
        

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                bool isHaveEnoughSpace = _consumableRes.Count < _storageСapacity;
                if (isHaveEnoughSpace && isTakingResourcesFinished)
                {
                    Debug.LogWarning($"I work i take");
                    StartCoroutine(TakingResourcesFromPlayer(inventory, 0));
                }
                else if (!isHaveEnoughSpace) print($"WareHouse is full!");
                else print($"Wait For Taking!");
            }
        }
    }
}
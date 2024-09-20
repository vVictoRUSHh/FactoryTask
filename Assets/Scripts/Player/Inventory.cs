using System;
using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using MainMechanic.WareHouse;
using Player;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public List<IConsumableResource>_resourcesInInventory;
   public int _inventoryCapacity;
   public InventoryDisplay _inventoryDisplay;
   public CounterResourceDistance _counterOfDistance;
   private bool isTakingResourcesFinished = true;
   float distanceBetweenBlocks;


   private void Awake()
   {
      _resourcesInInventory = new List<IConsumableResource>();
      _counterOfDistance = new CounterResourceDistance();
   }
   private IEnumerator TakingResourcesFromWareHouse(ManufacturedWareHouse manufacturedWareHouse, int index)
   {
      isTakingResourcesFinished = false;

      _resourcesInInventory.Add(manufacturedWareHouse._consumableResources[index]);
      manufacturedWareHouse._consumableResources.RemoveAt(index);
        
      yield return new WaitForSeconds(1f);
      isTakingResourcesFinished = true;
   }

   private void OnTriggerStay(Collider other)
   {
      if (other.TryGetComponent(out ManufacturedWareHouse manufacturedWareHouse))
      {
            bool canTakeResources = _resourcesInInventory.Count < _inventoryCapacity;
            bool empty = manufacturedWareHouse._consumableResources.Count == 0;
            int lastItem = manufacturedWareHouse._consumableResources.Count - 1;
            if (!empty && canTakeResources && isTakingResourcesFinished)
            {
               StartCoroutine(TakingResourcesFromWareHouse(manufacturedWareHouse, lastItem));
               _inventoryDisplay.DisplayInventory(this,_resourcesInInventory.Count - 1,_counterOfDistance.CountDistance(this));
               
               print($"I take 1 iron from storage! {_resourcesInInventory.Count} ");
            }
            else if (!canTakeResources) print($"Inventory is full!");
            else print($"Wait For Taking!");
      }
   }
}
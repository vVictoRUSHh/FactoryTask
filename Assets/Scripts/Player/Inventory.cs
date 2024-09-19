using System;
using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using MainMechanic.WareHouse;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public List<IConsumableResource>_resourcesInInventory;
   public int _inventoryCapacity;
   public InventoryDisplay _inventoryDisplay;
   private bool isTakingResourcesFinished = true;
   float distanceBetweenBlocks = 0;


   private void Awake()
   {
      _resourcesInInventory = new List<IConsumableResource>();
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
            if (!empty && canTakeResources && isTakingResourcesFinished)
            {
               StartCoroutine(TakingResourcesFromWareHouse(manufacturedWareHouse, 0));
               _inventoryDisplay.DisplayInventory(this,0,distanceBetweenBlocks);
               distanceBetweenBlocks +=0.50f;
               print($"I take 1 iron from storage! {_resourcesInInventory.Count} ");
            }
            else if (!canTakeResources) print($"Inventory is full!");
            else print($"Wait For Taking!");
      }
   }
}
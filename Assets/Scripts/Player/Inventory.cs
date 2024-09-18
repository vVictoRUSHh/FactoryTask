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

   private void Awake()
   {
      _resourcesInInventory = new List<IConsumableResource>();
   }

   private void OnTriggerStay(Collider other)
   {
      
      if (other.TryGetComponent(out ManufacturedWareHouse manufacturedWareHouse))
      {
         for (int i = 0; i < manufacturedWareHouse._consumableResources.Count; i++)
         {
            Debug.LogError($"This is ittiratio by nubmer{i}");
            bool canTakeResources = _resourcesInInventory.Count < _inventoryCapacity ? true : false;
            if (canTakeResources)
            {
               manufacturedWareHouse.GiveResourcesToPlayer(1, this, i);
               _inventoryDisplay.DisplayInventory(this,i);
               print($"I take 1 iron from storage! {_resourcesInInventory.Count} ");
            }
            else print($"Inventory is full!");
            
            continue;
            Debug.LogWarning($"Hellow i finish the ittaration!");
         }
      }
   }
}
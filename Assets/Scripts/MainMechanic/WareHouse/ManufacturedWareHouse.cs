﻿using System;
using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using UnityEngine;

namespace MainMechanic.WareHouse
{
    public class ManufacturedWareHouse : MonoBehaviour
    {
        public int _storageСapacity;
        public float _speedOfAdding;
        public List<IConsumableResource> _consumableResources;
        public List<INonConsumableResource> _nonConsumableResources;
        public Action onManufacturedWareHouseFilled;

        private void Awake()
        {
            _consumableResources = new List<IConsumableResource>();
        }

        public void GiveResourcesToPlayer(float speedOfTaking,Inventory inventory,int iterations)
        {
            inventory._resourcesInInventory.Add(_consumableResources[iterations]);
            _consumableResources.Remove(_consumableResources[iterations]);
        }

        
    }
}

using System.Collections.Generic;
using MainMechanic.FactoryResources;
using UnityEngine;

namespace MainMechanic.WareHouse
{
    public class ManufacturedWareHouse : MonoBehaviour
    {
        public int _storageСapacity;
        public List<IConsumableResource> _consumableResources;
        public List<INonConsumableResource> _nonConsumableResources;
        

    }
}

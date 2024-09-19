using UnityEngine;

namespace Player
{
    public class CounterResourceDistance
    {
        public float CountDistance(Inventory inventory)
        {
            int resourceCount = inventory._resourcesInInventory.Count;

            if (resourceCount < 1) return 0; 
            if (resourceCount > 10) resourceCount = 10;

            return 0.5f * resourceCount;
        }

    }
}
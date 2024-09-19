using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{

    public Transform _playerBack;
    public GameObject _iron;
    public void DisplayInventory(Inventory inventory,int itemIndex,float distanceBetween)
    {
        if (inventory._resourcesInInventory[itemIndex].GetType() == typeof(Iron))
        {
            GameObject resource = Instantiate(_iron, _playerBack);
            resource.transform.position =
                new Vector3(resource.transform.position.x, resource.transform.position.y + distanceBetween , resource.transform.position.z);
        }
    }


}
using System;
using MainMechanic.WareHouse;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{

    public Transform _playerBack;
    public GameObject _iron;
    public GameObject _copper;
    private ConsumerWareHouse consumerWareHouse;
    public void DisplayInventory(Inventory inventory,int itemIndex,float distanceBetween)
    {
        if (inventory._resourcesInInventory[itemIndex].GetType() == typeof(Iron))
        {
            GameObject resource = Instantiate(_iron, _playerBack);
            resource.transform.position =
                new Vector3(resource.transform.position.x, resource.transform.position.y + distanceBetween , resource.transform.position.z);
        }
        else  if (inventory._resourcesInInventory[itemIndex].GetType() == typeof(Copper))
        {
            GameObject resource = Instantiate(_copper, _playerBack);
            resource.transform.position =
                new Vector3(resource.transform.position.x, resource.transform.position.y + distanceBetween , resource.transform.position.z);
        }
    }

    private void DeleteVisualResource()
    {
        if (_playerBack.childCount > 0)
        {
            Transform lastChild = _playerBack.GetChild(_playerBack.childCount - 1);
            Destroy(lastChild.gameObject);
        }
    }

    private void OnEnable()
    {
        ConsumerWareHouse.onResurceTakes += DeleteVisualResource;
    }

    private void OnDisable()
    {
       
        ConsumerWareHouse.onResurceTakes -= DeleteVisualResource;
    }
}
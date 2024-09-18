using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{

    public Transform _playerBack;
    public GameObject _iron;
    public void DisplayInventory(Inventory inventory,int iteration)
    {
        if (inventory._resourcesInInventory[iteration].GetType() == typeof(Iron))
        {
            GameObject resource = Instantiate(_iron, _playerBack);
            resource.transform.position =
                new Vector3(resource.transform.position.x, resource.transform.position.y + iteration , resource.transform.position.z);
            Debug.LogWarning($"Itteration{iteration}");
        }
      
    }


}
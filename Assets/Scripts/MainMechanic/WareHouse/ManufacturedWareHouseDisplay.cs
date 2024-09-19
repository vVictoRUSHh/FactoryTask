using MainMechanic.WareHouse;
using TMPro;
using UnityEngine;

public class ManufacturedWareHouseDisplay : MonoBehaviour
{
    private ManufacturedWareHouse manufacturedWareHouse;
    [SerializeField]private TMP_Text _countInfo;
    private void Awake()
    {
        manufacturedWareHouse = GetComponent<ManufacturedWareHouse>();
    }

    private void Update()
    {
        _countInfo.text = $"{(manufacturedWareHouse._consumableResources.Count).ToString()}" +
                          $"/{manufacturedWareHouse._storageСapacity.ToString()}";
    }
}
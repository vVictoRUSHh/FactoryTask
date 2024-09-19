using MainMechanic.WareHouse;
using TMPro;
using UnityEngine;

public class ConsumerWareHouseDisplay : MonoBehaviour
{
    public ConsumerWareHouseController consumerWareHouseWareHouse;
    [SerializeField]private TMP_Text _countInfoIron;
    [SerializeField]private TMP_Text _countInfoCopper;
    private void Update()
    {
        _countInfoIron.text = $"Кол железа {consumerWareHouseWareHouse._ironList.Count.ToString() }";
        _countInfoCopper.text = $"Кол меди {consumerWareHouseWareHouse._copperList.Count.ToString()} ";
    }
}
using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using MainMechanic.WareHouse;
using UnityEngine;

public class ConsumerWareHouseController : MonoBehaviour
{
    public ConsumerWareHouse _consumerWareHouse;
    public List<Iron> _ironList = new List<Iron>();
    public List<Copper> _copperList = new List<Copper>();
    public BronzeFactory _bronzeFactory;
    public CopperFactory _copperFactory;
    public GameObject _ironPrefab;
    public GameObject _copperPrefab;

    private ResourceMover _resourceMover; 
    public float _speed;

    private void Awake()
    {
        _resourceMover = new ResourceMover();
    }

    private void SortingResources()
    {
        if (_consumerWareHouse._consumableRes.Count == 0) return;

        var lastItem = _consumerWareHouse._consumableRes.Count - 1;
        var item = _consumerWareHouse._consumableRes[lastItem];

        if (item is Iron ironItem)
        {
            _ironList.Add(ironItem);
            _consumerWareHouse._consumableRes.Remove(item);
        }
        else if (item is Copper copperItem)
        {
            _copperList.Add(copperItem);
            _consumerWareHouse._consumableRes.Remove(item);
        }
    }

    private void OnEnable()
    {
        ConsumerWareHouse.onResurceTakes += SortingResources;
    }

    private void OnDisable()
    {
        ConsumerWareHouse.onResurceTakes -= SortingResources;
    }

    private void GivingResources()
    {
        if (_ironList.Count > 0 && _copperList.Count > 0)
        {
            int lastItemIron = _ironList.Count - 1;
            int lastItemCopper = _copperList.Count - 1;
            
            if (lastItemIron >= 0 && lastItemCopper >= 0)
            {
                _bronzeFactory._ironList.Add(_ironList[lastItemIron]);
                _ironList.RemoveAt(lastItemIron);
                _bronzeFactory._copperList.Add(_copperList[lastItemCopper]);
                _copperList.RemoveAt(lastItemCopper);
                DisplayResourceGiving(_ironPrefab,_copperPrefab);
            }
        }
        if (_ironList.Count > 0 && _copperList.Count == 0)
        {
            int lastItem = _ironList.Count - 1;

            if (lastItem >= 0)
            {
                _copperFactory._ironList.Add(_ironList[lastItem]);
                _ironList.RemoveAt(lastItem);
                DisplayResourceGiving(_ironPrefab);
            }
        }

    }
    private void DisplayResourceGiving(GameObject prefabToSpawn)
    {
        GameObject iron = Instantiate(prefabToSpawn, transform);
        StartCoroutine(_resourceMover.MoveResource(iron, _copperFactory.transform.position, _speed));
    }
    private void DisplayResourceGiving(GameObject prefabToSpawn,GameObject secondPrefabToSpawn)
    {
        GameObject iron = Instantiate(prefabToSpawn, transform);
        StartCoroutine(_resourceMover.MoveResource(iron, _bronzeFactory.transform.position, _speed));
        GameObject copper = Instantiate(secondPrefabToSpawn, transform);
        StartCoroutine(_resourceMover.MoveResource(copper, _bronzeFactory.transform.position, _speed));
    }
    private void Update()
    {
        GivingResources();
    }
}

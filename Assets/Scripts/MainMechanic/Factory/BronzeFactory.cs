using System.Collections;
using System.Collections.Generic;
using MainMechanic.FactoryResources;
using MainMechanic.WareHouse;
using Unity.Mathematics;
using UnityEngine;

public class BronzeFactory : Factory
{
    public ManufacturedWareHouse _manufacturedWareHouse;
    public float timeToMake;
    public GameObject _bronzePrefab;
    public List<Iron> _ironList;
    public List<Copper> _copperList;
    private Bronze _bronzeResource;
    private bool isCreatingFinish = true;
    public float _speed;
    private ResourceMover _resourceMover;

    private void Awake()
    {
        _resourceMover = new ResourceMover();
    }

    public override void CreateResource()
    {
        var resourceCountInWareHouse = _manufacturedWareHouse._consumableResources.Count;
        var resourcesCopacity = _manufacturedWareHouse._storageСapacity;
        bool haveEnoughResources = _ironList.Count > 0 && _copperList.Count > 0;
        isWorking  = resourceCountInWareHouse < resourcesCopacity && haveEnoughResources;
        if (isWorking && isCreatingFinish)
        {
            StartCoroutine(MakeResourceCoroutine(timeToMake));
            debugInfo = $"Factory is Working!!!";
        }
        else if (resourceCountInWareHouse >= resourcesCopacity)
            debugInfo = $"Factory stop working because WareHouse is filled!";
        else 
            debugInfo = $"Factory have no resource to creating!";  
    }

    private void Update()
    {
        if (isCreatingFinish)CreateResource();
    }

    private IEnumerator MakeResourceCoroutine(float timeToMake)
    {
        isCreatingFinish = false;
        _ironList.RemoveAt(_ironList.Count-1);
        _copperList.RemoveAt(_copperList.Count-1);
        yield return new WaitForSeconds(timeToMake);
        _bronzeResource = new Bronze();
        _manufacturedWareHouse._nonConsumableResources.Add(_bronzeResource);
        DisplayResourceAdding();
        isCreatingFinish = true;
    }

    private void DisplayResourceAdding()
    {
        GameObject bronze = Instantiate(_bronzePrefab,gameObject.transform.position,quaternion.identity);
        StartCoroutine(_resourceMover.MoveResource(bronze, _manufacturedWareHouse.gameObject.transform.position, _speed));
    }
}
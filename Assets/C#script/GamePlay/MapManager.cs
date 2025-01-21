using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float offectY;
    public List<GameObject> MapList;
    private GameObject Maptarget;
    private int LastIndex;
    public void Check()
    {
        if((transform.position.y - Camera.main.transform.position.y) < offectY / 2)
        {
            SetMap();
            transform.position = new Vector3(0, Camera.main.transform.position.y + offectY, 0);
        }
    }
    private void SetMap()
    {
        var index = Random.Range(0, MapList.Count);
        while(LastIndex == index)
        {
            index = Random.Range(0, MapList.Count);
        }
        Maptarget = MapList[index];
        Instantiate(Maptarget, transform.position, Quaternion.identity);
        LastIndex = index;
    }
    private void OnEnable()
    {
        StringEventSO.GetPointEvent += OnCheck;
    }
    private void OnCheck(int obj)
    {
        Check();
    }
    private void OnDisable()
    {
        StringEventSO.GetPointEvent -= OnCheck;
    }
}

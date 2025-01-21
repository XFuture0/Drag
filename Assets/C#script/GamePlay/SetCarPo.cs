using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarPo : MonoBehaviour
{
    public int direction;
    public List<GameObject> CarList;
    private void Start()
    {
        InvokeRepeating("SetCar", 0.2f, Random.Range(5f, 7f));
    }
    private void SetCar()
    {
        var index = Random.Range(0,CarList.Count);
      var car = Instantiate(CarList[index],transform.position,Quaternion.identity,transform);
        car.GetComponent<MoveForward>().dir = direction;
    }
}

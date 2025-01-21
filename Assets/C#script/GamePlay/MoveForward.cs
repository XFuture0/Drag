using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int dir;
    public float Speed;
    private Vector2 StartPo;
    private void Start()
    {
        StartPo = transform.position;
        transform.localScale = new Vector3(dir, 1, 1);
    }
    private void Update()
    {
        if(math.abs(transform.position.x - StartPo.x) >= 25)
        {
            Destroy(gameObject);
        }
        Move();
    }
    private void Move()
    {
        transform.position += transform.right * Speed *dir * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void Update()
    {
        Check();
    }
    private void Check()
    {
        if((Camera.main.transform.position.y - transform.position.y) > 50)
        {
            Destroy(gameObject);
        }
    }
}

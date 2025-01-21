using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaremaControll : MonoBehaviour
{
    public Transform Frag;
    public float offectY;//ÇàÍÜÎ»ÒÆÆ«ÒÆ
    private float ratio;//ÆÁÄ»³ß´ç
    public float zoomBase;//Ä¬ÈÏ³ß´ç
    private void Awake()
    {
        ratio = (float)Screen.height / (float)Screen.width;
        Camera.main.orthographicSize = zoomBase * ratio * 0.5f;//ÆÁÄ»³ß´ç×ÔÊÊÓ¦ 
    }
    private void LateUpdate()//ÔÚÇàÍÜÌøÔ¾Ê±ÂıÒ»Ö¡
    {
        transform.position = new Vector3(transform.position.x,Frag.position.y + offectY * ratio,transform.position.z);
    }
}

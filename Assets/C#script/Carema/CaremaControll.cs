using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaremaControll : MonoBehaviour
{
    public Transform Frag;
    public float offectY;//����λ��ƫ��
    private float ratio;//��Ļ�ߴ�
    public float zoomBase;//Ĭ�ϳߴ�
    private void Awake()
    {
        ratio = (float)Screen.height / (float)Screen.width;
        Camera.main.orthographicSize = zoomBase * ratio * 0.5f;//��Ļ�ߴ�����Ӧ 
    }
    private void LateUpdate()//��������Ծʱ��һ֡
    {
        transform.position = new Vector3(transform.position.x,Frag.position.y + offectY * ratio,transform.position.z);
    }
}

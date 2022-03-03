using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    GameObject targetObj;
    Vector3 targetPos;
    //Vector3 pos;

    //回転させるスピード
    private float rotateSpeed = 0.5f;


    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;

        //transform.position = pos;

        targetPos = targetObj.transform.position;

        //回転させる角度
        float angle = Input.GetAxis("Horizontal") * rotateSpeed;

        //プレイヤー中心で回転
        transform.RotateAround(targetPos, Vector3.up, angle);
    }

}

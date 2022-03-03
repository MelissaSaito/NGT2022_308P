using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    GameObject targetObj;
    Vector3 targetPos;
    //Vector3 pos;

    //��]������X�s�[�h
    private float rotateSpeed = 0.5f;


    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
    }

    void Update()
    {
        // target�̈ړ��ʕ��A�����i�J�����j���ړ�����
        transform.position += targetObj.transform.position - targetPos;

        //transform.position = pos;

        targetPos = targetObj.transform.position;

        //��]������p�x
        float angle = Input.GetAxis("Horizontal") * rotateSpeed;

        //�v���C���[���S�ŉ�]
        transform.RotateAround(targetPos, Vector3.up, angle);
    }

}

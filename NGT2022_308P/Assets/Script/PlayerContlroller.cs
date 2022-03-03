using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ControllerA
//ControllerB
//ControllerX
//ControllerY
//ControllerZL
//ControllerZR


public class PlayerContlroller : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed = 10.0f;
    float slowMoveSpeed = 5.0f;
    GameObject UpperBody;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpperBody = GameObject.Find("UpperBody");

    }

    void Update()
    {
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        //slow�ړ�
        if (Input.GetKey(KeyCode.C) || Input.GetButton("ControllerB"))
        {
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * slowMoveSpeed + new Vector3(0, rb.velocity.y, 0);

            //���Cube������
            UpperBody.SetActive(false);


        }
        else
        {
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
            //���Cube�ʂ�
            UpperBody.SetActive(true);

        }

        transform.rotation = Quaternion.LookRotation(moveForward);


    }

}

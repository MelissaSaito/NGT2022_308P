using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

    //�}�b�v�̕\��
    GameObject map_item;
    [SerializeField] private Image map_image;
    bool map_function = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpperBody = GameObject.Find("UpperBody");
        map_item = GameObject.Find("map_item");
        map_image.enabled = false;
    }

    void Update()
    {
        inputVertical = Input.GetAxisRaw("Vertical");

        if(map_function == true && (Input.GetKeyUp(KeyCode.T) || Input.GetButtonUp("ControllerY")))
        {
            if (map_image.enabled == true)
            {
                map_image.enabled = false;
                return;
            }
            map_image.enabled = true;
        }
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


    //�ڐG�����������̏���
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject == map_item)
        {
            other.gameObject.SetActive(false);
            map_function = true;
        }
    }
}

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
    //speedMagnification�̓X�s�[�h���ߗp
    public float speedMagnification, slowSpeedMagnification;

    public Vector3 movingForce;
    private Vector3 movingDirection, movingVelocity;
    new Rigidbody rigidbody;

    public GameObject UpperBody; 

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //�R���g���[���[��L�X�e�B�b�N&WSAD���擾
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // 0 or 1�ɕϊ�
        movingDirection = new Vector3(x, 0, z);
        movingDirection.Normalize();// 0 or 1

        //Idle��
        if (movingDirection.x == 0 && movingDirection.z == 0)
        {

            Animator animator = GetComponent<Animator>();
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            movingVelocity.x = 0;
            movingVelocity.z = 0;

        }
        else
        {


            //slow�ړ�
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerB"))
            {
                //�m�F�p
                Debug.Log("yeah");

                //
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Slow", true);

                movingVelocity = movingDirection * slowSpeedMagnification;


            }
            //�ʏ�ړ�
            else
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", true);
                animator.SetBool("Slow", false);
                movingVelocity = movingDirection * speedMagnification;

            }


        }

        //������
        if (Input.GetButton("ControllerZL") || Input.GetButton("ControllerZR"))
        {
            //���Cube������
            UpperBody.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        this.rigidbody.AddForce(movingVelocity, ForceMode.Force);
    }
}


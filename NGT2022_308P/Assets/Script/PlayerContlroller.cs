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
    //speedMagnificationはスピード調節用
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
        //コントローラーのLスティック&WSAD情報取得
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // 0 or 1に変換
        movingDirection = new Vector3(x, 0, z);
        movingDirection.Normalize();// 0 or 1

        //Idle時
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


            //slow移動
            if (Input.GetKey(KeyCode.E) || Input.GetButton("ControllerB"))
            {
                //確認用
                Debug.Log("yeah");

                //
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Slow", true);

                movingVelocity = movingDirection * slowSpeedMagnification;


            }
            //通常移動
            else
            {
                Animator animator = GetComponent<Animator>();
                animator.SetBool("Walk", true);
                animator.SetBool("Slow", false);
                movingVelocity = movingDirection * speedMagnification;

            }


        }

        //聞き耳
        if (Input.GetButton("ControllerZL") || Input.GetButton("ControllerZR"))
        {
            //上のCube無くす
            UpperBody.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        this.rigidbody.AddForce(movingVelocity, ForceMode.Force);
    }
}


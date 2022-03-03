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
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        //slow移動
        if (Input.GetKey(KeyCode.C) || Input.GetButton("ControllerB"))
        {
            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * slowMoveSpeed + new Vector3(0, rb.velocity.y, 0);

            //上のCube無くす
            UpperBody.SetActive(false);


        }
        else
        {
            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
            //上のCube写す
            UpperBody.SetActive(true);

        }

        transform.rotation = Quaternion.LookRotation(moveForward);


    }

}

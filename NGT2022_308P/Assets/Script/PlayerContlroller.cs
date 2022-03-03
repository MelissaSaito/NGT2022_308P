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

    //マップの表示
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


    //接触があった時の処理
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject == map_item)
        {
            other.gameObject.SetActive(false);
            map_function = true;
        }
    }
}

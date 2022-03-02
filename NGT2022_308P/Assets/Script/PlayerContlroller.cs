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
    //speedMagnificationはスピード調節用
    public float speedMagnification, slowSpeedMagnification, jumpVec;

    private Vector3 movingDirection, movingVelocity;
    new Rigidbody rigidbody;
    Animator animator;

    // 地面に着地しているか判定する変数
    private bool grounded = false;

    //地面にいるときのdrag(抵抗)の値
    //private int groundedDrag = 10;
    //ジャンプ(空中)にいるときのdragの値
    //private int jumpDrag = 0;

    public float JumpPower;//  ジャンプ力

    // 抵抗値の変数
    private float dragTag;

    public GameObject UpperBody;

    //マップの表示
    [SerializeField] private Image map;
    bool map_on = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        map.enabled = false;
    }

    void Update()
    {
        if (map_on == true && (Input.GetKeyUp(KeyCode.T) || Input.GetButtonUp("ControllerY")))
        {
            if (map.enabled == true)
            {
                map.enabled = false;
                return;
            }
            map.enabled = true;
        }
    }

    void FixedUpdate()
    {
        //コントローラーのLスティック&WSAD情報取得
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        // 0 or 1に変換
        movingDirection = new Vector3(z, 0, x);
        movingDirection.Normalize();// 0 or 1

        //Idle時
        if (movingDirection.x == 0 && movingDirection.z == 0)
        {
            //上のCube無くす
            UpperBody.SetActive(true);

            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            movingVelocity.x = 0;
            movingVelocity.z = 0;

        }
        //歩き処理
        else
        {


            //slow移動
            if (Input.GetKey(KeyCode.C) || Input.GetButton("ControllerB"))
            {
                //確認用
                Debug.Log("yeah");

                //上のCube無くす
                UpperBody.SetActive(false);

                //
                animator.SetBool("Slow", true);

                movingVelocity = movingDirection * slowSpeedMagnification;


            }
            //通常移動
            else
            {
                //上のCube無くす
                UpperBody.SetActive(true);


                animator.SetBool("Walk", true);
                animator.SetBool("Slow", false);
                movingVelocity = movingDirection * speedMagnification;

            }


        }

        //歩き&slowの処理
        this.rigidbody.AddForce(movingVelocity, ForceMode.Force);


        //ジャンプ処理
        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody.AddForce(transform.up * jumpVec, ForceMode.Force);
        }
        if(grounded == false)
        {
            Gravity();

        }




        //聞き耳
        if (Input.GetButton("ControllerZL") || Input.GetButton("ControllerZR"))
        {
            //上のCube無くす
            UpperBody.SetActive(false);
        }
    }

    //接触があった時の処理
    void OnCollisionStay(Collision other)
    {

        if (other.collider.tag == "Stage")

        {
            grounded = true;
            Debug.Log("unko");
        }

        if (other.gameObject.name == "map_item")
        {
            Destroy(other.gameObject);
            map_on = true;
        }
    }
    //接触が離れた時の処理

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;

    }

    //重力
    void Gravity()
    {
        rigidbody.AddForce(new Vector3(0, -250, 0));
    }

}


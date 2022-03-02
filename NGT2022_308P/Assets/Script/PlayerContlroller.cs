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
    //speedMagnification�̓X�s�[�h���ߗp
    public float speedMagnification, slowSpeedMagnification, jumpVec;

    private Vector3 movingDirection, movingVelocity;
    new Rigidbody rigidbody;
    Animator animator;

    // �n�ʂɒ��n���Ă��邩���肷��ϐ�
    private bool grounded = false;

    //�n�ʂɂ���Ƃ���drag(��R)�̒l
    //private int groundedDrag = 10;
    //�W�����v(��)�ɂ���Ƃ���drag�̒l
    //private int jumpDrag = 0;

    public float JumpPower;//  �W�����v��

    // ��R�l�̕ϐ�
    private float dragTag;

    public GameObject UpperBody;

    //�}�b�v�̕\��
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
        //�R���g���[���[��L�X�e�B�b�N&WSAD���擾
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        // 0 or 1�ɕϊ�
        movingDirection = new Vector3(z, 0, x);
        movingDirection.Normalize();// 0 or 1

        //Idle��
        if (movingDirection.x == 0 && movingDirection.z == 0)
        {
            //���Cube������
            UpperBody.SetActive(true);

            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            movingVelocity.x = 0;
            movingVelocity.z = 0;

        }
        //��������
        else
        {


            //slow�ړ�
            if (Input.GetKey(KeyCode.C) || Input.GetButton("ControllerB"))
            {
                //�m�F�p
                Debug.Log("yeah");

                //���Cube������
                UpperBody.SetActive(false);

                //
                animator.SetBool("Slow", true);

                movingVelocity = movingDirection * slowSpeedMagnification;


            }
            //�ʏ�ړ�
            else
            {
                //���Cube������
                UpperBody.SetActive(true);


                animator.SetBool("Walk", true);
                animator.SetBool("Slow", false);
                movingVelocity = movingDirection * speedMagnification;

            }


        }

        //����&slow�̏���
        this.rigidbody.AddForce(movingVelocity, ForceMode.Force);


        //�W�����v����
        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody.AddForce(transform.up * jumpVec, ForceMode.Force);
        }
        if(grounded == false)
        {
            Gravity();

        }




        //������
        if (Input.GetButton("ControllerZL") || Input.GetButton("ControllerZR"))
        {
            //���Cube������
            UpperBody.SetActive(false);
        }
    }

    //�ڐG�����������̏���
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
    //�ڐG�����ꂽ���̏���

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;

    }

    //�d��
    void Gravity()
    {
        rigidbody.AddForce(new Vector3(0, -250, 0));
    }

}


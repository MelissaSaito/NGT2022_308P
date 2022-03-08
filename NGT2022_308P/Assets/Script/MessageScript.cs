using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    [SerializeField]
    private Message messageScript;// Message�X�N���v�g��ǂݍ���
    public string[] message;// �\�������郁�b�Z�[�W
    public string[] message1;// �\�������郁�b�Z�[�W
    public string[] message2;// �\�������郁�b�Z�[�W
    public string[] message3;// �\�������郁�b�Z�[�W
    public string[] message4;// �\�������郁�b�Z�[�W
    public string[] message5;// �\�������郁�b�Z�[�W

    private int talkFlag = 0;
    private int talkMax = 6;

    private string kaigyoo = "\n";

    private RaycastHit hit;
    public float rayDistance;
    public GameObject gameObject;
    private bool talk1 = true;
    private bool talk2 = true;


    void Start()
    {
        //StartCoroutine("Message");// Message�R���[�`�������s����
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))// A�L�[�������ꂽ��A
        //{
        //    talkFlag++;
        //}
        //if (talkFlag == 0)
        //{
        //    //StartCoroutine("Message", message);// Message�R���[�`�������s����

        //}
        //if (talkFlag == 1)
        //{
        //    StartCoroutine("Message", message1);// Message�R���[�`�������s����
        //}
        //if (talkFlag == 2)
        //{
        //    StartCoroutine("Message", message2);// Message�R���[�`�������s����
        //}
        //if (talkFlag == 3)
        //{
        //    StartCoroutine("Message", message3);// Message�R���[�`�������s����
        //}
        //if (talkFlag == 4)
        //{
        //    StartCoroutine("Message", message4);// Message�R���[�`�������s����
        //}
        //if (talkFlag == 5)
        //{
        //    StartCoroutine("Message", message5);// Message�R���[�`�������s����
        //}

    }

    //���͈͓̔��ɓ������Ƃ��i���̂�cllider�𔼌a�T�ō���Ă���j
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            //K�������Ɖ�b���󂯎���
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (talk1 == true)
                {
                    Debug.Log("���̕����͂����Ǝ���Ă��邾�낤��");
                    StartCoroutine("Message", message1);// Message�R���[�`�������s����
                    messageScript.talkflag = true;
                    talk1 = false;
                }
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            //Debug.Log(other.gameObject.name);

            //ray�ɓ�����������tag��Player��������"��������"�ƕԂ�
            if (other.gameObject.tag == ("Player"))
            {
                if (talk2 == true)
                {
                    StartCoroutine("Message", message2);// Message�R���[�`�������s����
                    messageScript.talkflag = true;
                    talk2 = false;
                }
            }
        }
        else
        {
            messageScript.talkflag = false;


            Debug.Log("Hit Nothing");
        }

        //Ray�̕\���iScene�Łj
        float distance = 100; // ��΂�&�\������Ray�̒���
        float duration = 3;   // �\�����ԁi�b�j

        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, distance))
        {
            GameObject hitObject = hit.collider.gameObject;
        }

    }



    IEnumerator Message(string[] Conversation)// Message�R���[�`�� 
    {
        yield return new WaitForSeconds(0.01f);// 0.01�b�҂�
        //messageScript.SetMessagePanel(message);// messageScript��SetMessagePanel�����s����

        messageScript.SetMessagePanel(Conversation);// messageScript��SetMessagePanel�����s����

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyRayScript : MonoBehaviour

{
    private RaycastHit hit;
    public float rayDistance;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    //���͈͓̔��ɓ������Ƃ��i���̂�cllider�𔼌a�T�ō���Ă���j
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            //K�������Ɖ�b���󂯎���
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("���̕����͂����Ǝ���Ă��邾�낤��");
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            //Debug.Log(other.gameObject.name);

            //ray�ɓ�����������tag��Player��������"��������"�ƕԂ�
            if (other.gameObject.tag == ("Player"))
            {
                Debug.Log("��������");
            }
        }
        else
        {
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
}


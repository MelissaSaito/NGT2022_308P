using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBox : MonoBehaviour
{
    GameObject Player;
    public bool GameClear = false;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�ڐG�����������̏���
    void OnCollisionStay(Collision other)
    {

        if (other.gameObject == Player)
        {

            if (Input.GetKeyDown(KeyCode.T) || Input.GetButtonDown("ControllerA"))
            {
                Debug.Log("�󕨂����");
                //���Cube�ʂ�
                this.gameObject.SetActive(false);
                GameClear = true;
            }

        }
    }

}

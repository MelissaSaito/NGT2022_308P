using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBox : MonoBehaviour
{
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //接触があった時の処理
    void OnCollisionStay(Collision other)
    {

        if (other.gameObject == Player)
        {

            if (Input.GetKeyDown(KeyCode.T) || Input.GetButtonDown("ControllerA"))
            {
                Debug.Log("宝物を入手");
                //上のCube写す
                this.gameObject.SetActive(false);
            }

        }
    }

}

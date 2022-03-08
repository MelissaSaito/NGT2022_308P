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

    //ÚG‚ª‚ ‚Á‚½‚Ìˆ—
    void OnCollisionStay(Collision other)
    {

        if (other.gameObject == Player)
        {

            if (Input.GetKeyDown(KeyCode.T) || Input.GetButtonDown("ControllerA"))
            {
                Debug.Log("•ó•¨‚ğ“üè");
                //ã‚ÌCubeÊ‚·
                this.gameObject.SetActive(false);
                GameClear = true;
            }

        }
    }

}

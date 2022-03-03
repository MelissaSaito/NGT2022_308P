using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animation _animation;

    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _animation.Play();
        }
    }
}


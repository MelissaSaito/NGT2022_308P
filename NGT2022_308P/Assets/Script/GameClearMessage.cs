using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClearMessage : MonoBehaviour
{
    GameObject Player;
    [SerializeField] private TMP_Text GameClear_image;
    bool GameClear_function = false;
    GameObject TresureBox;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        TresureBox = GameObject.Find("Tresure_Box");
        GameClear_image.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!TresureBox.activeSelf)
        {
            GameClear_image.enabled = true;
        }
    }
}

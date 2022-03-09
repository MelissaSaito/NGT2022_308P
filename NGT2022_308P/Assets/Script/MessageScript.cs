using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    [SerializeField]
    private Message messageScript;// Messageスクリプトを読み込む
    public string[] message;// 表示させるメッセージ
    public string[] message1;// 表示させるメッセージ
    public string[] message2;// 表示させるメッセージ
    public string[] message3;// 表示させるメッセージ
    public string[] message4;// 表示させるメッセージ
    public string[] message5;// 表示させるメッセージ

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
        //StartCoroutine("Message");// Messageコルーチンを実行する
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {

        ////会話消去機能----------------------------------------------------
        //if (messageScript.eraseTimeFlag == true)
        //{
        //    messageScript.displayTime += Time.deltaTime;

        //}
        //if (messageScript.displayTime >= 20.0f)
        //{
        //    //Debug.Log("消去フラグがたった");
        //    messageScript.eraseFlag = true;
        //    messageScript.eraseTimeFlag = false;
        //    messageScript.displayTime = 0.0f;
        //}
        ////経過時間後の消去フラグ
        //if (messageScript.eraseFlag == true)
        //{

        //    if (talk1 == false)
        //    {
        //        talk1 = true;
        //    }
        //    if (talk2 == false)
        //    {
        //        talk2 = true;
        //    }

        //    //Debug.Log("消去しました");
        //    messageScript.messageText.text = "";
        //    messageScript.eraseFlag = false;

        //}
        ////---------------------------------------------------------------------
    }


    //一定の範囲内に入ったとき（球体のclliderを半径５で作ってある）
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            //Kを押すと会話が受け取れる
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (talk1 == true)
                {
                    //Debug.Log("奥の部屋はちゃんと守られているだろうか");
                    StartCoroutine("Message", message1);// Messageコルーチンを実行する
                    messageScript.talkflag = true;
                    talk1 = false;
                }
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            //Debug.Log(other.gameObject.name);

            //rayに当たった物のtagがPlayerだった時"見つかった"と返す
            if (other.gameObject.tag == ("Player"))
            {
                if (talk2 == true)
                {
                    StartCoroutine("Message", message2);// Messageコルーチンを実行する
                    messageScript.talkflag = true;
                    talk2 = false;
                }
            }
        }
        else
        {
            messageScript.talkflag = false;


            //Debug.Log("Hit Nothing");
        }

        //Rayの表示（Sceneで）
        float distance = 100; // 飛ばす&表示するRayの長さ
        float duration = 3;   // 表示期間（秒）

        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, distance))
        {
            GameObject hitObject = hit.collider.gameObject;
        }

    }



    IEnumerator Message(string[] Conversation)// Messageコルーチン 
    {
        yield return new WaitForSeconds(0.01f);// 0.01秒待つ
        //messageScript.SetMessagePanel(message);// messageScriptのSetMessagePanelを実行する

        messageScript.SetMessagePanel(Conversation);// messageScriptのSetMessagePanelを実行する

    }


}

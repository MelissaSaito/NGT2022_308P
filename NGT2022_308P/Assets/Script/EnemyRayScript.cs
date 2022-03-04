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


    //一定の範囲内に入ったとき（球体のclliderを半径５で作ってある）
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            //Kを押すと会話が受け取れる
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("奥の部屋はちゃんと守られているだろうか");
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            //Debug.Log(other.gameObject.name);

            //rayに当たった物のtagがPlayerだった時"見つかった"と返す
            if (other.gameObject.tag == ("Player"))
            {
                Debug.Log("見つかった");
            }
        }
        else
        {
            Debug.Log("Hit Nothing");
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
}


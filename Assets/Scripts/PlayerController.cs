using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    float speed = 0.1f;
    float jump = 2;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = true;

        transform.position = new Vector3(0f, 1f, 0f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

    }

    private void Update()
    {
        direction();
        position();
        reStart();

        action();
    }


    //メソッド

    public void direction() // ,が＜　.が＞　に対応してカメラの方向を３０度づつ変換
    {
        if (Input.GetKeyDown(KeyCode.Period))
        {
            Vector3 rot = this.transform.eulerAngles;
            rot.y += 30;

            transform.eulerAngles = rot;
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            Vector3 rot = this.transform.eulerAngles;
            rot.y -= 30;

            transform.eulerAngles = rot;
        }
    }

    public void position()　//WASDをplayerの座標に対応
    {
        Vector3 pos = transform.position;
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        pos.x += hori * speed;
        pos.z += vert * speed;

        transform.position = pos;
    }

    public void reStart() //落ちたら(高さ-1より低くなったら)戻る
    {
        Vector3 pos = transform.position;
        if (pos.y <= -1)
        {
            pos.x = 0;
            pos.y = 3;
            pos.z = 0;
            transform.position = pos;
        }
    }

    public void action() //Jを押すとジャンプ,位置が0以上の時
    {
        Vector3 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.J) && pos.y >= 0)
        {
            pos.y += jump;
            transform.position = pos;
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; //ターゲットへの参照


    
    private void Start()
    {
        
    }

    
    private void Update()
    {
        position();
        direction();
    }



    public void direction()
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

    private void position()
    {
        Vector3 pos = target.position;
        Vector3 rot = this.transform.eulerAngles;

        pos.y += 3;
        pos.z += -5; 

        rot.x = 20;

        transform.position = pos;
        transform.eulerAngles = rot;
    }


}

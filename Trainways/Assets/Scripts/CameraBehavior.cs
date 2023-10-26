using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    public float Switch = 1;
    public KeyCode switchcam;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (Switch == 1)
        {
            target = GameObject.Find("Player").transform;
            LateUpdate();
        }
        else
        {
            target = GameObject.Find("Train").transform;
            LateUpdate();
        }
    }

    void LateUpdate()
    {
        if (Input.GetKey(switchcam))
        {
            if (Switch == 1)
            {
                Switch = 2;
                Start();
                GameObject.Find("Player").GetComponent<PlayerBehavior>().enabled = false;
                //player.GameComponent<PlayerBehavior>().enabled = false;
                GameObject.Find("Train").GetComponent<PlayerBehavior>().enabled = true;
                //player.GameComponent<PlayerBehavior>().enabled = true;
            }
            else
            {
                Switch = 1;
                Start();
                GameObject.Find("Player").GetComponent<PlayerBehavior>().enabled = true;
                //player.GameComponent<PlayerBehavior>().enabled = true;
                GameObject.Find("Train").GetComponent<PlayerBehavior>().enabled = false;
                //player.GameComponent<PlayerBehavior>().enabled = false;
            }
        }
        this.transform.position = target.TransformPoint(camOffset);

        this.transform.LookAt(target);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool playable;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playable)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.back * speed);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
            }
        }
    }
}

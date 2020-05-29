using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public PlatformController p;

    public Material pressed;
    public Material unpressed;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Domino")
        {
            raisePlatform();
            gameObject.GetComponent<Renderer>().material = pressed;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Domino")
        {
            gameObject.GetComponent<Renderer>().material = unpressed;
        }
    }

    void raisePlatform()
    {
        p.raise();
    }
}

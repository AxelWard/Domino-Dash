using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed;

    private bool goUp;

    private void Start()
    {
        goUp = false;
    }

    private void Update()
    {
        if(goUp)
        {
            if(gameObject.transform.position.y < 10)
            {
                gameObject.transform.Translate(gameObject.transform.up * Time.deltaTime * speed);
            } 
            else
            {
                goUp = false;
            }
        }
    }
    public void raise()
    {
        goUp = true;
    }

    public void stopRaise()
    {
        goUp = false;
    }
}

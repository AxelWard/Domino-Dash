using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    private Vector3 startPostition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPostition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;
    }

    public void TriggerReset()
    {
        gameObject.transform.position = startPostition;
        gameObject.transform.rotation = startRotation;

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }

        if(gameObject.name == "Platform")
        {
            gameObject.GetComponent<PlatformController>().stopRaise();
        }
    }
}

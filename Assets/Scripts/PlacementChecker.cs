using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    public Material valid;
    public Material invalid;

    private PlacementManager pm;

    private int collisionCount;

    private void Start()
    {
        pm = FindObjectOfType<PlacementManager>();
        gameObject.GetComponent<Renderer>().material = valid;
        collisionCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        pm.intersecting = true;
        gameObject.GetComponent<Renderer>().material = invalid;
        collisionCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        collisionCount--;
        if (collisionCount == 0)
        {
            pm.intersecting = false;
            gameObject.GetComponent<Renderer>().material = valid;
        }
    }

    public void place()
    {
        pm.intersecting = false;
        gameObject.GetComponent<Renderer>().material = valid;
        collisionCount = 0;
    }

    private void OnEnable()
    {
        collisionCount = 0;
        pm.intersecting = false;
        gameObject.GetComponent<Renderer>().material = valid;
    }
}

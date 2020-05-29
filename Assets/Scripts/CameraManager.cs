using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject placeCam;
    public GameObject raceCam;

    private bool place;
    
    // Start is called before the first frame update
    void Start()
    {
        placeCam.SetActive(true);
        raceCam.SetActive(false);

        place = true;
    }

    public void SwitchCams()
    {
        if(place)
        {
            raceCam.SetActive(true);
            placeCam.SetActive(false);
            place = false;
        }
        else
        {
            placeCam.SetActive(true);
            raceCam.SetActive(false);

            place = true;
        }
    }
}

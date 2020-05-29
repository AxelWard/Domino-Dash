using System.Dynamic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject startDomino;

    public float criticalAngle;

    public PlacementManager placementManager;
    public CameraManager camManager;
    public PauseMenuManager menuManager;

    private static int PLACE_STATE = 0;
    private static int PLAY_STATE = 1;
    
    private int state;
    private bool menu;

    private void Awake()
    {
        state = PLACE_STATE;
        placementManager.enterPlacementState();
        menu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu)
            {
                closeMenu();
            }
            else
            {
                openMenu();
            }
        }
        else if (state == PLACE_STATE)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = PLAY_STATE;
                FindObjectOfType<PlayerController>().playable = true;
                placementManager.exitPlacementState();
                camManager.SwitchCams();
            }
        }
        else if (state == PLAY_STATE)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = PLACE_STATE;
                resetLevel();
                FindObjectOfType<PlayerController>().playable = false;
                placementManager.enterPlacementState();
                camManager.SwitchCams();
            }
            
        }
    }

    private void FixedUpdate()
    {
        if(state == PLAY_STATE)
        {
            startPlay();
        }
    }

    public void closeMenu()
    {
        menuManager.deactivate();
        placementManager.enterPlacementState();
        menu = false;
    }

    public void openMenu()
    {
        menuManager.activate();
        placementManager.exitPlacementState();
        menu = true;
    }

    void startPlay()
    {
        Transform domino = startDomino.GetComponent<Transform>();

        if (domino.localRotation.x < criticalAngle)
        {
            Rigidbody rb = startDomino.GetComponent<Rigidbody>();
            Vector3 axis = -domino.right;

            rb.AddRelativeTorque(axis * 3f);
        }
    }

    void resetLevel()
    {
        GameObject[] resetArray = getResetables();

        for(int i = 0; i < resetArray.Length; i++)
        {
            resetArray[i].GetComponent<ResetScript>().TriggerReset();
        }
    }

    GameObject[] getResetables()
    {
        System.Collections.Generic.List<GameObject> resetList = new System.Collections.Generic.List<GameObject>();
        GameObject[] objectList = FindObjectsOfType<GameObject>();

        for(int i = 0; i < objectList.Length; i++)
        {
            if(objectList[i].GetComponent<ResetScript>() != null)
            {
                resetList.Add(objectList[i]);
            }
        }

        GameObject[] resetArray = resetList.ToArray();
        return resetArray;
    }
}

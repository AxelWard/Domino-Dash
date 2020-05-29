using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class PlacementManager : MonoBehaviour
{
    public LayerMask placeable;
    public LayerMask placed;

    public GameObject displayDomino;
    public GameObject placementDomino;
    public bool intersecting;

    private bool hover;
    private bool dominoHover;
    private bool placeState;

    private GameObject dDomino;
    private float rotation;

    // Update is called once per frame
    void Update()
    {
        if(placeState)
        {
            getHoverPosition();
            if (hover)
            {
                dDomino.transform.position = getHoverPosition() + new Vector3(0f, 1.6f, 0f);
                
                if(Input.GetMouseButtonDown(0))
                {
                    if (!intersecting)
                    {
                        Instantiate(placementDomino, getHoverPosition() + new Vector3(0f, 1.5f, 0f), Quaternion.Euler(0f, rotation, 0f));
                    }
                }
                else if (Input.mouseScrollDelta.y == 1)
                {
                    rotation += 30f;
                    dDomino.transform.Rotate(new Vector3(0f, 1f, 0f), 30);
                }
                else if (Input.mouseScrollDelta.y == -1)
                {
                    rotation -= 30f;
                    dDomino.transform.Rotate(new Vector3(0f, 1f, 0f), -30);
                }
            }

            if(dominoHover)
            {
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, placed.value);
                        Destroy(hit.collider.gameObject);
                        dDomino.GetComponent<PlacementChecker>().place();
                    }
                }
            }
        }
    }

    public void enterPlacementState()
    {
        placeState = true;
        rotation = 0f;
        dDomino = Instantiate(displayDomino, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public void exitPlacementState()
    {
        placeState = false;
        Destroy(dDomino);
    }

    private Vector3 getHoverPosition()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, placed.value))
        {
            hover = false;
            dominoHover = true;
            dDomino.SetActive(false);
            return hit.point;
        }
        else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, placeable.value))
        {
            hover = true;
            dominoHover = false;
            dDomino.SetActive(true);
            return hit.point;
        }
        else
        {
            hover = false;
            dominoHover = false;
            dDomino.SetActive(false);
            return new Vector3(0f, 0f, 0f);
        }
    }
}
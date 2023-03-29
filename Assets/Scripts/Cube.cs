using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Cube : MonoBehaviour
{

    public ARSessionOrigin arsessionorigin;
    public List<ARRaycastHit> raycasthits = new List<ARRaycastHit>();
    public GameObject cube;
    bool instanciatedCube =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detect the users touch i.e. when the user taps on the screen
        //Project the rays
        //Instanciate the virtual cube at the point where raycast meets the detected plane

        if (Input.GetMouseButton(0))
        {
            bool collision = arsessionorigin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycasthits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
            if (collision)
            {
                if (instanciatedCube == false)
                {
                    //instanciatedCube = Instantiate(cube);
                    cube.gameObject.SetActive(true);
                    instanciatedCube = true;
                    foreach (var plain in arsessionorigin.GetComponent<ARPlaneManager>().trackables)
                    {
                        plain.gameObject.SetActive(false);
                    }
                    arsessionorigin.GetComponent<ARPlaneManager>().enabled = false;
                }
                // instanciatedCube.transform.position = raycasthits[0].pose.position;
                cube.transform.position = raycasthits[0].pose.position;
            }
        }
    }
}

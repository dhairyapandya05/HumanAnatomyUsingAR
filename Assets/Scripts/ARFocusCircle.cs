using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;

public class ARFocusCircle : MonoBehaviour
{
    //public GameObject scanText;
    //public GameObject placeText;
    public ARSessionOrigin arsessionorigin;

    int objIndex;

    public GameObject[] virtual_objects;
    public GameObject[] buttons;

    public GameObject placementIndicator;
    //private GameObject carParent;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool placementIndicatorEnabled = true;

    bool isUIHidden = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        //scanText.SetActive(true);
        //placeText.SetActive(false);
    }

    void Update()
    {

        if (placementIndicatorEnabled == true)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }

        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    PlaceObject();
        //}
    }

    public void HideUI()
    {

        if (isUIHidden == false)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }

            placementIndicatorEnabled = false;
            placementIndicator.SetActive(false);

            foreach (var plain in arsessionorigin.GetComponent<ARPlaneManager>().trackables)
            {
                plain.gameObject.SetActive(false);
            }
            arsessionorigin.GetComponent<ARPlaneManager>().enabled = false;
            isUIHidden = true;
        }

        else if (isUIHidden == true)
        {

            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);
            }

            placementIndicatorEnabled = true;
            placementIndicator.SetActive(true);

            if (arsessionorigin.GetComponent<ARPlaneManager>().enabled == false)
            {
                foreach (var plain in arsessionorigin.GetComponent<ARPlaneManager>().trackables)
                {
                    plain.gameObject.SetActive(true);
                }
                arsessionorigin.GetComponent<ARPlaneManager>().enabled = true;
            }

            isUIHidden = false;

        }
    }

    public void PlaceObject()
    {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < buttons.Length; i++)
        {

            if (buttons[i].name == buttonName)
            {

                objIndex = i;
            }
        }

        virtual_objects[objIndex].SetActive(true);
        virtual_objects[(objIndex + 1)%buttons.Length].SetActive(false);
        virtual_objects[(objIndex + 2) % buttons.Length].SetActive(false);
        virtual_objects[objIndex].transform.position = placementPose.position;
        virtual_objects[objIndex].transform.rotation = placementPose.rotation;
    }



    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);

            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);
            }

            //scanText.SetActive(false);
            //placeText.SetActive(true);

            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);

            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }

            //placeText.SetActive(false);

        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}

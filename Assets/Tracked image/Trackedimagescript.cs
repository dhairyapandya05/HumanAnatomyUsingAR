using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Trackedimagescript : MonoBehaviour
{
    // Start is called before the first frame update
    ARTrackedImageManager artrackedimagemanager;
    public GameObject root_heart_model;
    public float speed = 1.0f;


    void Start()
    {
        artrackedimagemanager = GetComponent<ARTrackedImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        artrackedimagemanager.trackedImagesChanged += OnTrackedimagechanged;
    }


    private void OnDisable()
    {
        artrackedimagemanager.trackedImagesChanged -= OnTrackedimagechanged;

    }

    void OnTrackedimagechanged(ARTrackedImagesChangedEventArgs eventargs)
    {
        foreach (var trackedimg in eventargs.updated)
        {
            if (trackedimg.referenceImage.name == "heart")
            {

                //GameObject newObject = Instantiate(letter_A,spawnPosition, Quaternion.identity);

                root_heart_model.SetActive(true);
            }

        }
    }

}

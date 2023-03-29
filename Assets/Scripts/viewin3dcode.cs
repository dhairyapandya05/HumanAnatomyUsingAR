using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class viewin3dcode : MonoBehaviour
{
    public GameObject skeletonmodel;
    public ARSessionOrigin aRSessionOrigin;
    bool threeviewenabled = false;

    
    // Start is called before the first frame update
    void Start()
    {
        skeletonmodel.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void on3diconclicked()
    {

        Debug.Log("Button pressed");
        if (threeviewenabled == false)
        {
            skeletonmodel.SetActive(true);
            //Vector3 newPosition = new Vector3(aRSessionOrigin.transform.position.x, skeletonmodel.transform.position.y, aRSessionOrigin.transform.position.z);
            skeletonmodel.transform.position = aRSessionOrigin.transform.position;

            Vector3 newRotation = new Vector3(0, 180, 0);

            // Assign the new rotation vector to the GameObject
            skeletonmodel.transform.rotation = Quaternion.Euler(newRotation);
            //scaling the model twice


            //lets see
            //skeletonmodel.transform.localScale *= 2f;
            threeviewenabled = true;
            
        }

        if (threeviewenabled == true)
        {
            skeletonmodel.SetActive(false);
            threeviewenabled = false;
        }
       
    }
}

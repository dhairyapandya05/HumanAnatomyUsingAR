using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class Ambientlightestimation : MonoBehaviour
{
    public ARCameraManager cameraManager;
    private Light lightcomponent;
    public Text warningtext;
    public GameObject postprocessingvolume;
    // Start is called before the first frame update
    private void OnEnable()
    {
        lightcomponent = GetComponent<Light>();
 
        cameraManager.frameReceived += onCameraframereceived;
    }
    void onCameraframereceived(ARCameraFrameEventArgs aRCameraFrameEvent) {
        ARLightEstimationData led = aRCameraFrameEvent.lightEstimation;

        if (led.averageBrightness.HasValue)
        {
            lightcomponent.intensity = led.averageBrightness.Value;

            if(led.averageBrightness.Value < 0.3f && led.averageBrightness.Value > 0.1f)
            {
                postprocessingvolume.gameObject.SetActive(true);
            }

            if (led.averageBrightness.Value < 0.1f)
            {
                //show the warning
                warningtext.gameObject.SetActive(true);
                postprocessingvolume.gameObject.SetActive(true);

            }
            else
            {
                //disable the warning
                warningtext.gameObject.SetActive(false);
                postprocessingvolume.gameObject.SetActive(false);

            }



        }

        if (led.averageColorTemperature.HasValue)
        {
            lightcomponent.colorTemperature = led.averageColorTemperature.Value;
        }
    
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= onCameraframereceived;

    }
}

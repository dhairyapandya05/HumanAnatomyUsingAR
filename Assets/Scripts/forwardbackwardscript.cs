using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forwardbackwardscript : MonoBehaviour
{
    public void movingtonextscene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void movingtoprevious()
    {
        SceneManager.LoadScene("secondscene");
    }
}

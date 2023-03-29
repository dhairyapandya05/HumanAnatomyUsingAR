using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shifttothirdact : MonoBehaviour
{


    public void movingtonextnextscene()
    {
        SceneManager.LoadScene("thirdscene");
    }

    public void movingtopreviousprevious()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

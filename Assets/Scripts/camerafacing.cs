using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafacing : MonoBehaviour
{
    // Start is called before the first frame update
    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation*-Vector3.forward,Camera.main.transform.rotation*Vector3.up);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragtomove : MonoBehaviour
{
    private Touch touch;
    private float speedmodifier;
    // Start is called before the first frame update
    void Start()
    {
        speedmodifier = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedmodifier, transform.position.y, transform.position.z + touch.deltaPosition.y* speedmodifier);
            }
        }
    }
}

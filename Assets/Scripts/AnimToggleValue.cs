using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToggleValue : MonoBehaviour
{
    public string AnimValue = string.Empty;
    public float MaxValue = 1.0f;
    private float Descvalue = 0f;
    private float currentValue = 0f;
    public float speed = 2f;
    private Animator ThisAnimator = null;

    // Start is called before the first frame update
    private void Awake()
    {
        ThisAnimator = GetComponent<Animator>();
        Descvalue = currentValue = 0f;
    }

    public void ToggleValue()
    {
        Descvalue = (Descvalue < MaxValue) ? MaxValue : 0f;
    }
    private void Update()
    {
        currentValue = Mathf.Lerp(currentValue,Descvalue,Time.deltaTime*speed);
        ThisAnimator.SetFloat(AnimValue,currentValue);

        Debug.Log("Chal raha hai ");
    }
}

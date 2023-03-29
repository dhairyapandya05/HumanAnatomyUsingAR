using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private int Index = 0;
    public void ResetItems()
    {
        if (transform.childCount <= 0) return;
        Index = 0;
        for(int i=0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(Index).gameObject.SetActive(true);
    }
    private void Awake()
    {
        ResetItems();
    }

    public void NextItem()
    {
        if (transform.childCount <= 0) return;
        Index = Mathf.RoundToInt(Mathf.Repeat(Index+1,transform.childCount));

        for(int i=0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);

        }
        transform.GetChild(Index).gameObject.SetActive(true);

    }
}

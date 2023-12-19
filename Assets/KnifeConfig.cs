using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeConfig : MonoBehaviour
{
    [SerializeField]
    private Highlight highlight;

 

    // Update is called once per frame
    void Update()
    {
        if (highlight.isPickedUp)
        {         
                transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}

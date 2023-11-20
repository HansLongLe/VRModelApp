using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Camera.main.transform.eulerAngles;
    }
}

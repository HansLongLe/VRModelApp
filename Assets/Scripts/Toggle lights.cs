using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togglelights : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;

    public void SetLights()
    {
        Debug.Log("Hello");
        foreach (var light in lights)
        {
            light.SetActive(!light.activeSelf);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHair : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool returnHairstyle;
    private static GameObject oldHairstyle;
    private static GameObject newHairstyle;
    
    // Start is called before the first frame update
    private void Start()
    {
        oldHairstyle = model.transform.Find("Hair").gameObject;
    }

    public void Change()
    {
        if (returnHairstyle)
        {
            oldHairstyle.SetActive(true);
            Destroy(newHairstyle);
        }
        else
        {
            oldHairstyle.SetActive(false);
            newHairstyle = transform.Find("HairModel").gameObject;
            newHairstyle = Instantiate(newHairstyle);
            newHairstyle.transform.parent = model.transform;
            newHairstyle.transform.position = new Vector3(model.transform.position.x + offset.x, model.transform.position.y + offset.y,
                model.transform.position.z + offset.z);
            newHairstyle.SetActive(true);
            newHairstyle.transform.eulerAngles = model.transform.eulerAngles;
        }
        
    }
}

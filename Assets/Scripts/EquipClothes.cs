using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipClothes : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private Material[] materials;
    private SkinnedMeshRenderer oldClothes;

    // Start is called before the first frame update
    private void Start()
    {
        oldClothes = model.transform.Find("Body").gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    public void OnWear()
    {
        oldClothes.materials = materials;
    }
}

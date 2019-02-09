using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject WeaponObject;

    // Start is called before the first frame update
    void Start()
    {
        var weapon = WeaponObject.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = weapon.WeaponImage;
        GetComponentInChildren<TextMesh>().text = weapon.WeaponName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

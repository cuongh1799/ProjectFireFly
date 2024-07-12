using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class getAmmoAmount : MonoBehaviour
{
    public GameObject weapon;
    public TMP_Text bulletamount;
    [HideInInspector]
    public float amount;
    GunScript gs;

    // Start is called before the first frame update
    void Start()
    {
       gs = weapon.GetComponent<GunScript>();
       amount = gs.getBulletCount();
       //Debug.Log("current ammo is " + amount);
       bulletamount.text = "Ammo: " + amount;
    }

    // Update is called once per frame
    void Update()
    {
        amount = gs.getBulletCount();
        if(amount == 0)
        {
            bulletamount.text = "Reloading";
        }
        else 
        {
            bulletamount.text = "Ammo: " + amount;
        }
        //Debug.Log("current ammo is " + amount);
    }
}

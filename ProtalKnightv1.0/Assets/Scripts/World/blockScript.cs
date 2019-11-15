using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class blockScript : MonoBehaviour
{
    Inventory inv;
    public int id;
    void Start()
    {
        inv = GameObject.Find("Play").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {

        inv.AddItem(id);      
        Destroy(this.gameObject);
    }
}



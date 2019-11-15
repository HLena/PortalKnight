using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ESTE SCRIPT PERMITE AL CROSSOVER PERMANECER ENCIMA DE LA CABEZA DEL JUGADOR
public class CrossOverScript: MonoBehaviour
{
    public GameObject cross; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        cross.transform.position = namePos;
    }
}

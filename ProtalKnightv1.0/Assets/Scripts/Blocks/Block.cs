using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Unity Setup")]
    //public ParticleSystem deathParticles;
    //private AudioSource audio;
    Inventory inv;
    public int idBlock;
    //public string nameBlock;
    void Start()
    {
        inv = GameObject.Find("Play").GetComponent<Inventory>();
        //audio = GetComponent<AudioSource>();
        //audio.sta
    }

    private void Update()
    {
        
    }

   /* private void OnMouseDown()
    {
        inv.AddItem(idBlock);
        Destroy(this.gameObject);
        //audio.Play();     
    }*/

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sphere"))
        {

        }
    }*/


}

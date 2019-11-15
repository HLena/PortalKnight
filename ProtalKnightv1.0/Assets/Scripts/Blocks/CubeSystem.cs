using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//este script se añade al RigidBodyFPSController
public class CubeSystem : MonoBehaviour
{
    Inventory inv;
    //Sistema cubo para crear o destruir bloques
    private GameObject block;
    //public int currentId;

    Ray r;
    RaycastHit rh;
    void Start()
    {
        inv = GameObject.Find("Play").GetComponent<Inventory>();
    }

    void Update()
    {
        //si presiono con el mouse se puede realizar dos acciones
        //Debug.Log("------ "+inv.ItemSelected.Title+" ---------");
        if (Input.GetMouseButtonDown(0) && inv.ItemSelected != null)
        {
            r = Camera.main.ScreenPointToRay(Input.mousePosition);            
            if (Physics.Raycast(r, out rh))
            {
                Debug.Log("-----1-------");
                if (rh.collider != null)
                {
                    Debug.Log("-----2-------");
                    var c = rh.collider.GetComponent<Cube>();
                    if (rh.collider.GetComponent<Cube>() != null)
                    {
                        Debug.Log("-----3------");
                        //si es verdadero -> destruye bloque
                        if (inv.mode == 1)
                        {
                            Debug.Log("-----Destruir-------");
                            StartCoroutine(DelayedDestruction(rh.collider, c.destructionTime, c.idCube));                            
                        }
                        else if(inv.ItemSelected != null) //si es falso -> crea un bloque en la posicion del puntero
                        {
                            Debug.Log("-------Construir---------");
                            ItemData current = inv.selectedItem.transform.GetComponent<ItemData>();
                            if (current.amount >= 1)
                            {
                                GameObject go = Instantiate(Resources.Load(inv.ItemSelected.Slug)) as GameObject;
                                go.transform.position = rh.collider.transform.position + rh.normal;
                                current.amount--;
                                //data = slots[i].transform.GetChild(1).GetComponent<ItemData>();
                                current.transform.GetChild(0).GetComponent<Text>().text = current.amount.ToString();
                            }
                            else
                            {
                                Destroy(inv.slots[current.slotId].GetComponent<ItemData>());
                                inv.items[current.slotId] = inv.database.GetComponent<ItemDatabase>().database[0];
                                //current = null;
                                inv.ItemSelected = null;
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

    }

    IEnumerator DelayedDestruction(Collider col, int timeToDestroy, int currentId)
    {
        bool destroy = true;
        for(int i = 0; i < timeToDestroy; i++)
        {
            r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out rh))
            {
                if (rh.collider != col)
                {
                    destroy = false;
                    break;
                }
            }
            else
            {
                destroy = false;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        if (destroy)
        {
            Destroy(col.gameObject);
            inv.AddItem(currentId);            
        }
    }

}

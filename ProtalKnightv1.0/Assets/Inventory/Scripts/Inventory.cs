using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public ItemDatabase database;

    public GameObject baul;
    public GameObject cinturon;
    public GameObject slot;
    public GameObject slotBar;
    public GameObject item;
    public GameObject title;

    private bool EnabledItem = false;
    public Image selectedItem;
    public Item ItemSelected = null;
    public ItemData currentItemData = null;
    public int mode; //si es falso destruye elementos / si es true construye

    private int totalSlotsBaul = 36;
    private int totalSlotsCinturon = 9;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    bool Enabled = false;

    public AudioSource playsound;


    void Start()
    {
        database = gameObject.GetComponent<ItemDatabase>();

        for (int i = 0; i < totalSlotsCinturon; i++)
        {
            items.Add(database.GetItemById(-1));
            slots.Add(Instantiate(slotBar));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(cinturon.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
            if (i + 1 < totalSlotsCinturon)
                slots[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            else
                slots[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "E";

        }

        for (int i = totalSlotsCinturon; i < totalSlotsBaul; i++)
        {
            items.Add(database.GetItemById(-1));
            slots.Add(Instantiate(slot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(baul.transform);
            slots[i].GetComponent<RectTransform>().transform.localScale = Vector3.one;
        }

        //AddItem(4);
        AddItem(5); // el sprite con id=5 es el 
        //  AddItem(-1);    
        //AddItem(3);
    }

    void Update()
    {

        DisplayInventory();
        ManagerInventoyBar();
    }


    public void AddItem(int id)
    {

        Item itemToAdd = database.GetItemById(id);

        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    ItemData data;
                    if (i < totalSlotsCinturon)
                    {
                        data = slots[i].transform.GetChild(1).GetComponent<ItemData>();

                    }
                    else
                    {
                        data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    }
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(item);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slotId = i;
                    itemObj.GetComponent<ItemData>().amount = 1;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.name = itemToAdd.Title;
                    itemObj.transform.localScale = Vector3.one;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.transform.position = Vector2.zero;
                    slots[i].name = "Slot: " + itemToAdd.Title;
                    break;
                }
            }
        }
    }

    public void DeleteItem(int id)
    {

        Item itemToDelete = database.GetItemById(id);

        if (itemToDelete.Stackable && CheckIfItemIsInInventory(itemToDelete))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    ItemData data  = slots[i].transform.GetChild(0).GetComponent<ItemData>();                    
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            
        }

    }




    bool CheckIfItemIsInInventory(Item item)
    {        
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == item.Id)
            {
                return true;
            }
        }
        return false;
    }

    void DisplayInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Enabled = !Enabled;
        }
        if (Enabled)
        {
            baul.SetActive(true);
            title.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            baul.SetActive(false);
            title.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    void ManagerInventoyBar()
    {
        if (Input.anyKeyDown)
        {
            switch (Input.inputString)
            {
                case "1":
                    UseItemsOfInventory(0);
                    Debug.Log("key 1");
                    break;
                case "2":
                    UseItemsOfInventory(1);
                    Debug.Log("key 2");
                    break;
                case "3":
                    UseItemsOfInventory(2);
                    Debug.Log("key 3");
                    break;
                case "4":
                    UseItemsOfInventory(3);
                    Debug.Log("key 4");
                    break;
                case "5":
                    UseItemsOfInventory(4);
                    Debug.Log("key 5");
                    break;
                case "6":
                    UseItemsOfInventory(5);
                    Debug.Log("key 6");
                    break;
                case "7":
                    UseItemsOfInventory(6);
                    Debug.Log("key 7");
                    break;
                case "8":
                    UseItemsOfInventory(7);
                    Debug.Log("key 8");
                    break;               
                default:                   
                    break;
            }
        }
    }

    void UseItemsOfInventory(int x)
    {
        //playsound.Play();            
        if (selectedItem == null)
        {
            ItemSelected = items[x];
            selectedItem = slots[x].transform.GetChild(1).GetComponent<Image>();           
            currentItemData = slots[x].transform.GetChild(1).GetComponent<ItemData>();
            selectedItem.rectTransform.sizeDelta = new Vector2(61, 61);            
            //Debug.Log("-------" + ItemSelected.Title);

        }
        else
        {
            selectedItem.rectTransform.sizeDelta = new Vector2(41, 41);            
            selectedItem = slots[x].transform.GetChild(1).GetComponent<Image>();
            currentItemData = slots[x].transform.GetChild(1).GetComponent<ItemData>();
            selectedItem.rectTransform.sizeDelta = new Vector2(61, 61);            
            ItemSelected = items[x];
        }

        if(ItemSelected.Id == 5)
        {
            mode = 1;
            Debug.Log("Modo Destruir");
        }
        else
        {
            mode = 0;
            Debug.Log("Modo Construir");
        }
        //Debug.Log("--------"+mode+"--------");


    }
}
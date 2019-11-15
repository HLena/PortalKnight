using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {

	public List<Item> database = new List<Item>();
	private JsonData itemData;
  

	void Start()
	{
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Inventory/JsonFiles/Items.json"));
		ConstructItemDatabase();	
	}

	public Item GetItemById(int id)
	{
		for (int i = 0; i < database.Count; i++)
		{
			if (database[i].Id == id)
			{
				return database[i];
			}
		}
		return database[0];
	} 
    void ConstructItemDatabase()
	{
		for (int i = 0; i < itemData.Count; i++)
		{
			Item newItem = new Item(
                (int)itemData[i]["id"],
                itemData[i]["title"].ToString(),
                (bool)itemData[i]["stackable"],
                itemData[i]["slug"].ToString());
			database.Add(newItem);		
		}
	}

    
}

[System.Serializable]
public class Item
{
   

    public int Id;
    public string Title;
    public string Slug;
    public Sprite Sprite;
    public bool Stackable;  
    public Item(int id, string name, bool stackable, string slug)
    {      
        this.Id = id;
        this.Title = name;
        this.Stackable = stackable;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);

    }
}
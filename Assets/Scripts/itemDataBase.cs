using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class itemDataBase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;

	void Start()
	{
		itemData = JsonMapper.ToObject (File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json")); 
		ConstructItemDatabase ();
	}

	public Item FetchItemByID(int id)
	{
		for (int i = 0; i < database.Count; i++)
			if(database[i].ID == id)
				return database[i];
		return null;
	}

	void ConstructItemDatabase()
	{
		for (int i = 0; i < itemData.Count; i++) 
		{
			database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"], itemData[i]["type"].ToString(), itemData[i]["stats"]["damage"].ToString(),
				(int)itemData[i]["stats"]["strength"], (int)itemData[i]["stats"]["stamina"], (int)itemData[i]["stats"]["critchance"], (int)itemData[i]["stats"]["intellect"], (int)itemData[i]["stats"]["armor"],
				itemData[i]["description"].ToString(), (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString()));
		}
	}

}

public class Item
{
	public int ID { get; set;}
	public string Title { get; set; }
	public int Value { get; set; }
	public string Type { get; set; }
	public string Damage { get; set; }
	public int Strength { get; set; }
	public int Stamina { get; set; }
	public int CritChance { get; set; }
	public int Intellect { get; set; }
	public int Armor { get; set; }
	public string Description { get; set; }
	public bool Stackable { get; set; }
	public int Rarity { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; }

	public Item(int id, string title, int value, string type, string damage, int strength, int stamina, int critchance, int intellect, int armor, string description, bool stackable, int rarity, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Type = type;
		this.Damage = damage;
		this.Strength = strength;
		this.Stamina = stamina;
		this.CritChance = critchance;
		this.Intellect = intellect;
		this.Armor = armor;
		this.Description = description;
		this.Stackable = stackable;
		this.Rarity = rarity;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/" + slug);
	}

	public Item()
	{
		this.ID = -1;
	}
}
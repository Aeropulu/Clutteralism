using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private List<InventoryElement> list;
    private RectTransform inventory;
    public RectTransform elementprefab;
    
	// Use this for initialization
	void Start () {
        list = new List<InventoryElement>(40);
        inventory = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(ResourceType t)
    {
        RectTransform r = Instantiate(elementprefab, inventory);
        r.GetComponent<UnityEngine.UI.Image>().sprite = t.sprite;
        list.Add(new InventoryElement(t, r));
        
    }

    public bool RemoveItem(ResourceType t)
    {
        bool r = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].type == t)
            {
                Destroy(list[i].representation.gameObject);
                list.RemoveAt(i);
                r = true;
                break;
            }
        }
        return r;
    }

    public bool Contains(ResourceType t)
    {
        bool r = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].type == t)
            {
                r = true;
                break;
            }
        }
        return r;
    }
    

}

public struct InventoryElement
{
    public ResourceType type;
    public RectTransform representation;

    public InventoryElement(ResourceType t, RectTransform r)
    {
        type = t;
        representation = r;
    }
}

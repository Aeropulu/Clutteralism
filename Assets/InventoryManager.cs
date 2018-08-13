using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    private List<InventoryElement> list;
    private RectTransform inventory;
    public RectTransform elementprefab;

    public ResourceType[] StartResources;
    
	// Use this for initialization
	void Start () {
        
    }

    public void Init()
    {
        list = new List<InventoryElement>(40);
        inventory = GetComponent<RectTransform>();
        for (int i = 0; i < StartResources.Length; i++)
        {
            AddItem(StartResources[i], transform.position);

        }
    }

    public void AddItem(ResourceType t, Vector3 from)
    {
        RectTransform r = Instantiate(elementprefab, inventory);
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(inventory);
        r.GetComponent<UnityEngine.UI.Image>().sprite = t.sprite;
        /*var layout = r.GetComponent<UnityEngine.UI.LayoutElement>();
        layout.CalculateLayoutInputHorizontal();
        layout.CalculateLayoutInputVertical();
        Debug.Log(transform.position);*/
        var anim = r.GetComponent<ElementAnimation>();
        anim.from = from;
        anim.to = r.position;
        anim.enabled = true;
        anim.type = t;
        anim.list = list;

        //list.Add(new InventoryElement(t, r));
        
    }

    public bool RemoveItem(ResourceType t, Vector3 to)
    {
        bool r = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].type == t)
            {
                //Destroy(list[i].representation.gameObject);
                var anim = list[i].representation.gameObject.GetComponent<ElementAnimation>();
                anim.from = list[i].representation.position;
                anim.to = to;
                anim.isDestroyed = true;
                
                anim.enabled = true;
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

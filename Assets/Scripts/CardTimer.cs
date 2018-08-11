using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTimer : MonoBehaviour {
    public bool isActive = false;
    public bool isAvailable = false;
    public float duration = 1.0f;
    public AnimationClip timerclip;
    public GameObject mask;
    private float timerstate = 0.0f; // between 0 and 1
    public RectTransform inventoryElement;
    public InventoryManager SourceInventory;
    public InventoryManager DestinationInventory;
    public List<ResourceType> input;
    public List<ResourceType> output;
    public CardType type;
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isAvailable)
            return;
        timerstate += Time.deltaTime / duration;
        if (timerstate > 1.0f)
        {
            if (isActive)
            {
                timerstate -= 1.0f;
                
                Process();
                
            }
            else
                isAvailable = true;
            
        }
            
        timerclip.SampleAnimation(mask, timerstate);
	}

    private void OnDisable()
    {
        //timerstate = 1.0f;
        //timerclip.SampleAnimation(mask, timerstate);
    }
    private void OnEnable()
    {
        //timerstate = 0.0f;
        //timerclip.SampleAnimation(mask, timerstate);
    }

    private void Process()
    {
        bool allInputsPresent = true;
        foreach (ResourceType t in input)
        {
            if (!SourceInventory.Contains(t))
            {
                allInputsPresent = false;
                break;
            }
        }
        if (allInputsPresent)
        {
            foreach (ResourceType t in input)
                SourceInventory.RemoveItem(t);
            foreach (ResourceType t in output)
                DestinationInventory.AddItem(t);

        }

        /*if (input.Count > 0)
        {
            if (inventory.RemoveItem(input[0]))
                inventory.AddItem(output[0]);
        }
        else
            inventory.AddItem(output[0]);*/

    }
}

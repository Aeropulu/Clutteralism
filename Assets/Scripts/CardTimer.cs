using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;

public class CardTimer : MonoBehaviour {
    public bool isActive = false;
    public bool isAvailable = false;
    public float duration = 1.0f;

    //public Animation anim;

    public AnimationClip timerclip;
    public GameObject mask;
    private float timerstate = 0.0f; // between 0 and 1
    public RectTransform inventoryElement;
    public InventoryManager SourceInventory;
    public InventoryManager DestinationInventory;
    public List<ResourceType> input;
    public List<ResourceType> output;
    public CardType type;
    public float delay = 0.25f;
    private float wait = 0.0f;
    private bool willProduce = false;

    public UnityEngine.UI.Image image;

    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
        GetComponent<UnityEngine.UI.Image>().color = type.color;
        if (type.sprite)
            image.sprite = type.sprite;

    }
	
	// Update is called once per frame
	void Update () {
        if (isAvailable)
            return;
        timerstate += Time.deltaTime / duration * GameState.GameSpeed;
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
        
        //anim.clip.SampleAnimation(mask, timerstate);

        if (willProduce)
        {
            if (wait <= 0.0f)
            {
                foreach (ResourceType t in output)
                    DestinationInventory.AddItem(t, transform.position);
                willProduce = false;
                audioSource.Play();
            }
            wait -= Time.deltaTime;
        }

	}

    public void Activate()
    {
        isActive = true;
        isAvailable = false;
        duration = type.duration;
        timerstate = 0.0f;
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
                SourceInventory.RemoveItem(t, transform.position);
            /*foreach (ResourceType t in output)
                DestinationInventory.AddItem(t, transform.position);*/
            willProduce = true;
            wait = delay;

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

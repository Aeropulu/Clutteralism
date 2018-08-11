using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour {

    public RectTransform CardPrefab;
    public InventoryManager SourceInventory;
    public InventoryManager DestinationInventory;
    public CardType[] cardTypes;
    private PlaySpots spots;
	// Use this for initialization
	void Start () {
        spots = GetComponent<PlaySpots>();
        for (int i = 0; i < spots.cardspots.Length; i++)
        {
            SpawnCard(i);
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnCard(int i)
    {
        

        RectTransform t = spots.cardspots[i];
        var c = Instantiate(CardPrefab);
        CardTimer timer = c.GetComponent<CardTimer>();
        timer.SourceInventory = SourceInventory;
        timer.DestinationInventory = DestinationInventory;
        int index = Random.Range(0, cardTypes.Length);
        CardType type = cardTypes[index];
        timer.type = type;
        timer.output = new List<ResourceType>(type.output);
        timer.input = new List<ResourceType>(type.input);
        //timer.duration = type.duration;

        c.SetParent(t, false);
        spots.cardspots[i] = c;
    }
}

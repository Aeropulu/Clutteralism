using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour {

    //public SpawnCards Opponent;
    public RectTransform CardPrefab;
    public AudioClip DefaultSound;
    public InventoryManager SourceInventory;
    public InventoryManager DestinationInventory;
    public CardType[] DefaultCard;
    //public CardType[] cardTypes;
    //public List<CardType> availableCards;
    public List<CardType> Deck;
    
    private PlaySpots spots;
	// Use this for initialization
	void Start () {
        SourceInventory.Init();
        spots = GetComponent<PlaySpots>();
        //availableCards = new List<CardType>(cardTypes.Length);
        //UpdateCardList();
        for (int i = 0; i < spots.cardspots.Length; i++)
        {
            SpawnCard(i);
            
        }
        
	}
	/*
	private void UpdateCardList()
    {
        for (int i = 0; i < cardTypes.Length; i++)
        {
            if (!availableCards.Contains(cardTypes[i]))
            {
                int inputPresent = 0;
                // this type is not currently available, check the inventory for inputs
                foreach(ResourceType t in cardTypes[i].input)
                {
                    if (SourceInventory.Contains(t))
                        inputPresent++;
                }
                if (inputPresent >= cardTypes[i].input.Length)
                    availableCards.Add(cardTypes[i]);
            }
        }
    }*/

    public void SpawnCard(int i)
    {



        //UpdateCardList();

        RectTransform t = spots.cardspots[i];
        var c = Instantiate(CardPrefab);
        

        CardTimer timer = c.GetComponent<CardTimer>();
        timer.SourceInventory = SourceInventory;
        timer.DestinationInventory = DestinationInventory;
        if (Deck.Count <= 0)
        {
            Deck.Add(DefaultCard[Random.Range(0, DefaultCard.Length)]);
        }
        int index = Random.Range(0, Deck.Count);
        CardType type = Deck[index];

        AudioSource source = c.GetComponent<AudioSource>();
        if (type.PlaySound)
            source.clip = type.PlaySound;
        else
            source.clip = DefaultSound;

        Deck.RemoveAt(index);
        // add one random card from the list
        //AddCardToOpponentDeck(type);
        timer.type = type;
        timer.output = new List<ResourceType>(type.output);
        timer.input = new List<ResourceType>(type.input);
        if (timer.input.Count == 0)
            timer.delay = 0.0f;

        c.SetParent(t, false);
        spots.cardspots[i] = c;
    }

    public void AddCardToDeck(CardType PlayedType)
    {
        if (PlayedType.Draw.Length > 0)
        {
            int random = Random.Range(0, PlayedType.Draw.Length);
            Deck.Add(PlayedType.Draw[random]);
        }
    }
}

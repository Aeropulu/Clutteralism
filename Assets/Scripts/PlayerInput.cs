using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public RectTransform cursor;
    //public RectTransform[] cards;
    //public RectTransform[] factories;
    private int whatcard = 0;
    private RectTransform[] current = null;
    private int selectedcard = 0;
    private PlaySpots spots = null;
    private SpawnCards spawn = null;

    public InputScheme inputScheme;
   

	// Use this for initialization
	void Start () {
        spots = GetComponent<PlaySpots>();
        spawn = GetComponent<SpawnCards>();
        current = spots.cardspots;
        MoveCursor();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessInput();

    }

    private void ProcessInput()
    {
        inputScheme.ProcessInputs();
        if (inputScheme.right)
        {
            whatcard++;
            if (whatcard >= current.Length)
                whatcard -= current.Length;
            MoveCursor();
        }
        if (inputScheme.left)
        {
            whatcard--;
            if (whatcard < 0)
                whatcard += current.Length;
            MoveCursor();
        }
        if (inputScheme.confirm)
        {
            if (current == spots.cardspots)
                SelectCard();
            else
                PlayCard();

        }
    }

    void MoveCursor()
    {
        if (current[whatcard].GetComponent<CardTimer>())
            cursor.SetParent(current[whatcard].parent, false);
        else
            cursor.SetParent(current[whatcard], false);
        
        cursor.SetAsFirstSibling();
    }

    void SelectCard()
    {
        CardTimer timer = current[whatcard].GetComponent<CardTimer>();
        
        if (current[whatcard].GetComponent<CardTimer>() == null)
            return;
        if (!timer.isAvailable)
            return;
        selectedcard = whatcard;
        current = spots.factoryspots;
        MoveCursor();
    }

    void PlayCard()
    {
        RectTransform card = spots.cardspots[selectedcard];
        CardTimer timer = card.GetComponent<CardTimer>();
        
        if (current[whatcard].GetComponent<CardTimer>() != null)
        {
            RectTransform oldcard = current[whatcard];
            current[whatcard] = (RectTransform)oldcard.parent;
            MoveCursor();
            Destroy(oldcard.gameObject);
        }
        
        spots.cardspots[selectedcard] = (RectTransform) card.parent;
        card.SetParent(current[whatcard], false);
        current[whatcard] = card;
        timer.isActive = true;
        timer.isAvailable = false;
        timer.duration = timer.type.duration;
        spawn.SpawnCard(selectedcard);
        current = spots.cardspots;
        MoveCursor();
    }
}

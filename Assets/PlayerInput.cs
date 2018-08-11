using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public RectTransform cursor;
    public RectTransform[] cards;
    public RectTransform[] factories;
    private int whatcard = 0;
    private RectTransform[] current = null;
	// Use this for initialization
	void Start () {
        current = cards;
        MoveCursor();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessInput();

    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            whatcard++;
            if (whatcard >= cards.Length)
                whatcard -= cards.Length;
            MoveCursor();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            whatcard--;
            if (whatcard < 0)
                whatcard += cards.Length;
            MoveCursor();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (current == cards)
                current = factories;
            else
                current = cards;
            MoveCursor();
        }
    }

    void MoveCursor()
    {
        //cursor.position = cards[whatcard].position;
        cursor.SetParent(current[whatcard], false);
    }
}

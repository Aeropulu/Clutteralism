using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Card Type")]
public class CardType : ScriptableObject {
    public ResourceType[] input;
    public ResourceType[] output;

    public CardType[] Draw;
    public AudioClip PlaySound;
    public float duration = 1.0f;
    public Sprite sprite;
    public Color color = Color.white;
	
}

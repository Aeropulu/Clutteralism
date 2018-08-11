using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Card Type")]
public class CardType : ScriptableObject {
    public ResourceType[] input;
    public ResourceType[] output;

    public float duration = 1.0f;

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InputScheme : ScriptableObject {
    public bool up, down, left, right, confirm, cancel, discard;
    public abstract void ProcessInputs();
	
}


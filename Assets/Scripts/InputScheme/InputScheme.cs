using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InputScheme : ScriptableObject {

    public string Name;
    public GameObject PanelPrefab;
    public bool up, down, left, right, confirm, cancel;
    public abstract void ProcessInputs();
	
}


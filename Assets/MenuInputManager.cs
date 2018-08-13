using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputManager : MonoBehaviour {

    public InputScheme[] schemes;
    public MenuNavigator current;

    public bool confirm = false;
    public bool cancel = false;

	// Use this for initialization
	void Start () {
        current.Init();
        current.Enter();
	}
	
	// Update is called once per frame
	void Update () {
        confirm = false;
        cancel = false;
		foreach (InputScheme s in schemes)
        {
            s.ProcessInputs();
            if (s.up && current.Up)
            {
                current.Leave();
                current = current.Up;
                current.Enter();
            }
            if (s.down && current.Down)
            {
                current.Leave();
                current = current.Down;
                current.Enter();
            }
            if (s.left && current.Left)
            {
                current.Leave();
                current = current.Left;
                current.Enter();
            }
            if (s.right && current.Right)
            {
                current.Leave();
                current = current.Right;
                current.Enter();
            }
            if (s.confirm)
                confirm = s.confirm;
            if (s.cancel)
                cancel = s.cancel;
        }
	}

    
}

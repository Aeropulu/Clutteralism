using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InputScheme : ScriptableObject {
    public bool left, right, confirm, cancel, discard;
    public abstract void ProcessInputs();
	
}

[CreateAssetMenu(menuName ="Keyboard Input Scheme")]
public class KeyboardScheme : InputScheme
{
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode ConfirmKey;
    public KeyCode CancelKey;
    public KeyCode DiscardKey;

    public override void ProcessInputs()
    {
        left = Input.GetKeyDown(LeftKey);
        right = Input.GetKeyDown(RightKey);
        confirm = Input.GetKeyDown(ConfirmKey);
        cancel = Input.GetKeyDown(CancelKey);
        discard = Input.GetKeyDown(DiscardKey);
    }
}
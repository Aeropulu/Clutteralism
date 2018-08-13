using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Controller Input Scheme")]
public class ControllerInput : InputScheme
{
    public string HorizontalAxis, VerticalAxis;
    public KeyCode ConfirmKey, CancelKey;
    public float Threshold = 0.5f;
    private int lastX = 0;
    private int lastY = 0;
    public override void ProcessInputs()
    {
        float X = Input.GetAxis(HorizontalAxis);
        float Y = Input.GetAxis(VerticalAxis);
        int IX = 0; int IY = 0;
        if (X < -Threshold)
            IX = -1;
        if (X > Threshold)
            IX = 1;
        if (X >= -Threshold && X <= Threshold)
            IX = 0;
        if (Y < -Threshold)
            IY = -1;
        if (Y > Threshold)
            IY = 1;
        if (Y >= -Threshold && Y <= Threshold)
            IY = 0;
        left = false;
        right = false;
        up = false;
        down = false;
        if (IX != lastX)
        {
            lastX = IX;
            if (IX == -1)
                left = true;
            if (IX == 1)
                right = true;

        }
        if (IY != lastY)
        {
            lastY = IY;
            if (IY == 1)
                down = true;
            if (IY == -1)
                up = true;
        }

        confirm = Input.GetKeyDown(ConfirmKey);
        cancel = Input.GetKeyDown(CancelKey);
    }
}

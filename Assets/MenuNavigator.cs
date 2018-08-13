using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour {

    
    public MenuNavigator Up;
    public MenuNavigator Down;
    public MenuNavigator Left;
    public MenuNavigator Right;

    public bool isSelected = false;

    private Animator anim;
    // Use this for initialization
    void Start () {
        Init();
	}

    public void Init()
    {
        if (!anim)
            anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Enter()
    {
        anim.SetTrigger("Select");
        isSelected = true;
    }

    public void Leave()
    {
        anim.SetTrigger("Deselect");
        isSelected = false;
    }
}

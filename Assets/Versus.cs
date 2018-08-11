using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;

public class Versus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        SceneManager.LoadScene("Versus", LoadSceneMode.single);
    }
}

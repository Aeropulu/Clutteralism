using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressConfirm : MonoBehaviour {

    public MenuInputManager menuInput;
    public PlayerInput leftInput, RightInput;
    public float delay = 1.0f;
	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetTrigger("Select");
        menuInput.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (delay > 0.0f)
            delay -= Time.deltaTime;
		if (menuInput.confirm && delay <= 0.0f)
        {
            leftInput.gameObject.SetActive(false);
            RightInput.gameObject.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
	}
}

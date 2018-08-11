using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardSelectImage : MonoBehaviour {
    public RectTransform InputGroup;
    public RectTransform OutputGroup;
    public RectTransform ImagePrefab;
    //public UnityEngine.UI.Image inputimage;
    //public UnityEngine.UI.Image outputimage;
    //public Sprite[] images;
    //public CardType[] types;
    //public CardType cardType;
    public CardTimer timer;

	// Use this for initialization
	void Start () {
        timer = GetComponent<CardTimer>();
        
        foreach(ResourceType t in timer.input)
        {
            RectTransform r = Instantiate(ImagePrefab, InputGroup);
            r.GetComponent<UnityEngine.UI.Image>().sprite = t.sprite;
        }
        foreach (ResourceType t in timer.output)
        {
            RectTransform r = Instantiate(ImagePrefab, OutputGroup);
            r.GetComponent<UnityEngine.UI.Image>().sprite = t.sprite;
        }
        /*if (timer.input.Count > 0)
        {
            //GetComponent<CardTimer>().input = cardType.input[0];
            //inputimage.sprite = timer.input[0].sprite;
            for
        }
        //GetComponent<CardTimer>().output = cardType.output[0];
        //outputimage.sprite = timer.output[0].sprite;*/


    }

    // Update is called once per frame
    void Update () {
		
	}
}

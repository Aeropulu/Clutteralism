using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAnimation : MonoBehaviour {

    public AnimationCurve Curve;
    public Vector3 from;
    public Vector3 to;
    public float duration = 0.25f;
    public UnityEngine.UI.LayoutElement layout;
    public UnityEngine.UI.Image image;
    public TrailRenderer trail;
    public bool isDestroyed = false;
    private float state = 0.0f;
    public ResourceType type;
    public List<InventoryElement> list;
    // Use this for initialization
    void Start () {
        //layout = GetComponent<UnityEngine.UI.LayoutElement>();
        
	}

    private void OnEnable()
    {
        //layout.ignoreLayout = true;
        state = 0.0f;
        //transform.position = from;
        image.enabled = false;
    }

    private void OnDisable()
    {
        layout.ignoreLayout = false;
        trail.enabled = false;
        if (isDestroyed)
            Destroy(gameObject);
        else
            list.Add(new InventoryElement(type, GetComponent<RectTransform>()));
    }

    

    // Update is called once per frame
    void Update () {
        if (from == null || to == null)
            return;
        if (!layout.ignoreLayout)
        {
            layout.ignoreLayout = true;
            image.enabled = true;
            trail.enabled = true;
        }
            
        state += Time.deltaTime / duration;
        float k = Curve.Evaluate(Mathf.Clamp01(state));
        transform.position = from + k * (to - from);
        if (state > 1.0f)
            this.enabled = false;
	}
}

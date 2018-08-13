using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSchemeSelector : MonoBehaviour {

    public int SelectedScheme = 0;
    public InputScheme[] schemes;
    public TMPro.TextMeshProUGUI text;
    private List<GameObject> panels;

    public MenuInputManager manager;
    public MenuNavigator navigator;

	// Use this for initialization
	void Start () {
        panels = new List<GameObject>(4);
        foreach (InputScheme s in schemes)
        {
            var p = Instantiate(s.PanelPrefab, this.transform);
            panels.Add(p);
            p.SetActive(false);
        }
        text.SetText(schemes[SelectedScheme].name);
        panels[SelectedScheme].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.confirm && navigator.isSelected)
        {
            panels[SelectedScheme].SetActive(false);
            SelectedScheme++;
            if (SelectedScheme >= schemes.Length)
            {
                SelectedScheme -= schemes.Length;
                
            }
            text.SetText(schemes[SelectedScheme].name);
            panels[SelectedScheme].SetActive(true);
        }
        if (manager.cancel && navigator.isSelected)
        {
            panels[SelectedScheme].SetActive(false);
            SelectedScheme--;
            if (SelectedScheme < 0)
            {
                SelectedScheme += schemes.Length;
                
            }
            text.SetText(schemes[SelectedScheme].name);
            panels[SelectedScheme].SetActive(true);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticSelection : MonoBehaviour {
    public Button[] buttons;
    public Text counter;
    public int maxAllowedSelections;
    private int selectedAmount;
    public List<int> selectedIndices = new List<int>();

    void Start() {
        int x = 0;
        foreach (Button b in buttons) {
            int tempx = x;
            b.onClick.AddListener(() => OnClick(tempx));
            x++;
        }
    }

    void Update() {
        if (counter != null)
            counter.text = "" + (maxAllowedSelections - selectedAmount);
    }

    public void OnClick(int index) {
        Image selectedImage = buttons[index].transform.GetChild(0).GetComponent<Image>();
        if (selectedIndices.Contains(index)) {
            selectedAmount--;
            selectedIndices.Remove(index);
            selectedImage.enabled = false;
        } else if (selectedAmount < maxAllowedSelections) {
            selectedAmount++;
            selectedIndices.Add(index);
            selectedImage.enabled = true;
        }
    }
}

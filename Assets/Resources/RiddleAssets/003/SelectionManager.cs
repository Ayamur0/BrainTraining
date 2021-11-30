using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour {
    public Button[] buttons;
    public Text counter;
    public Sprite selectedSprite;
    private int selectedAmount;
    private List<int> selectedIndices = new List<int>();

    void Start() {
        int x = 0, y = 0;
        foreach (Button b in buttons) {
            int tempx = x, tempy = y;
            b.onClick.AddListener(() => OnClick(tempx, tempy));
            x++;
            if (x >= 3) {
                y++;
                x = 0;
            }
        }
    }

    void Update() {
        counter.text = "" + (2 - selectedAmount);
    }

    public void OnClick(int x, int y) {
        Debug.Log("x " + x + " y " + y);
        int index = x + y * 3;
        Image selectedImage = buttons[index].transform.GetChild(0).GetComponent<Image>();
        Debug.Log(selectedImage.gameObject.name);
        if (selectedIndices.Contains(index)) {
            selectedAmount--;
            selectedIndices.Remove(index);
            selectedImage.enabled = false;
        } else if (selectedAmount < 2) {
            selectedAmount++;
            selectedIndices.Add(index);
            selectedImage.enabled = true;
        }
    }
}

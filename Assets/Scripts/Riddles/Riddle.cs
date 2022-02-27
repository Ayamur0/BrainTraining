using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Riddle : ScriptableObject {
    public RiddleInfo info;
    public Sprite resultAreaImage;
    public Sprite solutionSprite;
    public GameObject interactiveArea;

    private static XmlSerializer serializer = new XmlSerializer(typeof(RiddleInfo));

    virtual public void OnEnable() { }

    public void init(int id) {
        info = RiddleInfo.loadFromXML(id);
        solutionSprite = Resources.Load<Sprite>($"RiddleAssets/{idToString(id)}/solution") as Sprite;
        interactiveArea = Instantiate(Resources.Load<GameObject>($"RiddleAssets/{idToString(id)}/R{idToString(id)}")) as GameObject;
        resultAreaImage = Resources.Load<Sprite>($"RiddleAssets/{idToString(id)}/result") as Sprite;
    }

    virtual public bool checkResult() { return false; }

    virtual public bool isResultValid() { return false; }

    public void reducePoints() {
        info.points = Mathf.Clamp(info.minPoints, info.points - info.pointReduction, info.maxPoints);
    }

    public void Destroy() {
        Destroy(interactiveArea);
    }

    private string idToString(int id) {
        return id.ToString("000");
    }
}

using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

public class RiddleInfo {
    public const int RiddleAmount = 23;

    [XmlElement]
    public int id;
    [XmlElement]
    public string title;
    public bool completed;
    public int points;
    [XmlElement]
    public int maxPoints;
    [XmlElement]
    public int minPoints;
    public int pointReduction;
    [XmlArrayItem("value")]
    public string[] descriptionParagraphs;
    public string description = "";
    [XmlArrayItem("value")]
    public string[] solutionParagraphs;
    public string solution = "";
    [XmlElement]
    public bool autoSubmit;

    private static XmlSerializer serializer = new XmlSerializer(typeof(RiddleInfo));
    private static XmlSerializer simpleSerializer = new XmlSerializer(typeof(SimpleRiddleInfo));

    public static RiddleInfo loadFromXML(int id) {
        RiddleInfo info = new RiddleInfo();
        info.id = id;
        XmlDocument xmldoc = new XmlDocument();
        TextAsset textAsset = Resources.Load<TextAsset>($"RiddleAssets/{info.id.ToString("000")}/info");
        xmldoc.LoadXml(textAsset.text);
        using (XmlReader reader = new XmlNodeReader(xmldoc)) {
            info = serializer.Deserialize(reader) as RiddleInfo;
        }
        if (SaveDataManager.RiddleSaveData != null) {
            info.completed = SaveDataManager.RiddleSaveData.IsCompleted(id);
            info.points = SaveDataManager.RiddleSaveData.GetRemainingPoints(id);
        }
        info.pointReduction = (info.maxPoints - info.minPoints) / 5;
        foreach (string s in info.descriptionParagraphs) {
            if (info.description.Length > 0)
                info.description += "\n\n";
            string temp = s;
            temp = Regex.Replace(temp, @"\$([^$]+)\$", "<color=#b83e39>$1</color>");
            info.description += temp;
        }
        foreach (string s in info.solutionParagraphs) {
            if (info.solution.Length > 0)
                info.solution += "\n\n";
            info.solution += s;
        }
        return info;
    }

    [XmlRoot(ElementName = "RiddleInfo")]
    public class SimpleRiddleInfo {
        [XmlElement]
        public int id;
        [XmlElement]
        public string title;
        public bool completed;
        public int points;
        [XmlElement]
        public int maxPoints;
        [XmlArrayItem("value")]
        public string[] descriptionParagraphs;
    }

    public static SimpleRiddleInfo loadSimpleInfoFromXML(int id) {
        SimpleRiddleInfo info = new SimpleRiddleInfo();
        info.id = id;
        XmlDocument xmldoc = new XmlDocument();
        TextAsset textAsset = Resources.Load<TextAsset>($"RiddleAssets/{info.id.ToString("000")}/info");
        xmldoc.LoadXml(textAsset.text);
        using (XmlReader reader = new XmlNodeReader(xmldoc)) {
            info = simpleSerializer.Deserialize(reader) as RiddleInfo.SimpleRiddleInfo;
        }
        if (SaveDataManager.RiddleSaveData != null) {
            info.completed = SaveDataManager.RiddleSaveData.IsCompleted(id);
            info.points = SaveDataManager.RiddleSaveData.GetRemainingPoints(id);
        }
        return info;
    }
}

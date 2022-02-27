using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class SaveData {
    [Serializable]
    public class RiddleData {
        public int RemainingPoints;
		public bool completed;

        public RiddleData(int r, bool c) {
            RemainingPoints = r;
            completed = c;
        }
    }

    public int TotalPoints;
    public int stars = 0;

    public Dictionary<int, RiddleData> RiddleDataDict = new Dictionary<int, RiddleData>();

    public SaveData() {
		TotalPoints = 0;
        for (int i = 1; i <= RiddleInfo.RiddleAmount; i++) {
            RiddleInfo.SimpleRiddleInfo info = RiddleInfo.loadSimpleInfoFromXML(i);
            RiddleDataDict.Add(i, new RiddleData(info.maxPoints, false));
        }
    }

    public bool IsCompleted(int id) {
        return RiddleDataDict[id].completed;
    }

    public void complete(int id) {
        RiddleDataDict[id].completed = true;
    }

    public int GetRemainingPoints(int id) {
        return RiddleDataDict[id].RemainingPoints;
    }

    public void UpdateRemainingPoints(int id, int points) {
        RiddleDataDict[id].RemainingPoints = points;
    }

    public void UpdateTotalPoints(int points) {
        TotalPoints = points;
    }
}

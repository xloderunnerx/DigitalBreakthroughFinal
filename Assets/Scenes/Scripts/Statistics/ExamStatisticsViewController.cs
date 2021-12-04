using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ExamStatisticsViewController : MonoBehaviour
{
    public StatisticsExamDataList statisticsExamDataList;
    public TextMeshProUGUI time;
    public TextMeshProUGUI tries;
    public TextMeshProUGUI height;
    public TextMeshProUGUI tasks;
    public TextMeshProUGUI mistakes;
    public TextMeshProUGUI hits;
    public TextMeshProUGUI droneHealth;

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        var lastRecord = statisticsExamDataList.Value.ToList().LastOrDefault();
        var minutes = (int)lastRecord.flightTime / 60;
        var seconds = (int)(lastRecord.flightTime - minutes * 60);
        var minutesStr = minutes < 10 ? "0" + minutes : minutes.ToString();
        var secondsStr = seconds < 10 ? "0" + seconds : seconds.ToString();
        time.text = minutes + " мин. " + seconds + " сек.";
        tries.text = lastRecord.prevTries.ToString();
        height.text = ((int)lastRecord.maxHeight).ToString() + "м";
        tasks.text = (lastRecord.validTreesItems + 1) + "/9";
        mistakes.text = lastRecord.powerLinesEncounters.ToString();
        hits.text = lastRecord.hitsCount.ToString();
        droneHealth.text = lastRecord.droneHealthState.ToString() + "%";
    }
}

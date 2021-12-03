using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatisticsExamController : MonoBehaviour
{
    public static StatisticsExamController instance;
    public StatisticsExamDataList statisticsExamDataList;
    public StatisticsExamData statisticsExamData;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        statisticsExamData = new StatisticsExamData();
        statisticsExamData.prevTries = statisticsExamDataList.Value.Length;
    }

    public void UpdateHeight(float value)
    {
        if (value > statisticsExamData.maxHeight)
            statisticsExamData.maxHeight = value;
    }

    public void UpdateHits()
    {
        statisticsExamData.hitsCount += 1;
    }

    public void UpdateHealthState(int value)
    {
        statisticsExamData.droneHealthState = value;
    }

    public void UpdatePowerLinesEncounters()
    {
        statisticsExamData.powerLinesEncounters += 1;
    }

    public void UpdateWrongTrees()
    {
        statisticsExamData.wrongTreesItems += 1;
    }

    public void UpdateValidTrees()
    {
        statisticsExamData.validTreesItems += 1;
    }

    public void UpdateFallenWire()
    {
        statisticsExamData.powerLineCutOffTrack = true;
    }

    private void Update()
    {
        statisticsExamData.flightTime += Time.deltaTime;
    }

    public void SaveData()
    {
        var localStatisticsDataList = statisticsExamDataList.Value.ToList();
        localStatisticsDataList.Add(statisticsExamData);
        statisticsExamDataList.Value = localStatisticsDataList.ToArray();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatisticsPracticeController : MonoBehaviour
{
    public static StatisticsPracticeController instance;
    public StatisticsPracticeDataList statisticsPracticeDataList;
    public StatisticsPracticeData statisticsPracticeData;

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        statisticsPracticeData = new StatisticsPracticeData();
        statisticsPracticeData.prevTries = statisticsPracticeDataList.Value.Length;
        statisticsPracticeData.droneHealthState = 100;
    }

    public void UpdateHeight(float value)
    {
        if (value > statisticsPracticeData.maxHeight)
            statisticsPracticeData.maxHeight = value;
    }

    public void UpdateHits()
    {
        statisticsPracticeData.hitsCount += 1;
    }

    public void UpdateHealthState(int value)
    {
        statisticsPracticeData.droneHealthState = value;
    }

    public void UpdatePowerLinesEncounters()
    {
        statisticsPracticeData.powerLinesEncounters += 1;
    }

    public void UpdateWrongPowerplantUnit()
    {
        statisticsPracticeData.wrongPowerPlantItems += 1;
    }

    private void Update()
    {
        statisticsPracticeData.flightTime += Time.deltaTime;
    }

    public void SaveData()
    {
        var localStatisticsDataList = statisticsPracticeDataList.Value.ToList();
        localStatisticsDataList.Add(statisticsPracticeData);
        statisticsPracticeDataList.Value = localStatisticsDataList.ToArray();
    }
}

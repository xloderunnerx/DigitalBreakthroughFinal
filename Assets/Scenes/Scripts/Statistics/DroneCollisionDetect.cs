using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCollisionDetect : MonoBehaviour
{
    public bool isExam;
    uint health = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (isExam)
        {
            StatisticsExamController.instance.UpdateHits();
            health -= 10;
            StatisticsExamController.instance.UpdateHealthState((int)health);
        }
        else
        {
            StatisticsPracticeController.instance.UpdateHits();
            health -= 10;
            StatisticsPracticeController.instance.UpdateHealthState((int)health);
        }
    }
}

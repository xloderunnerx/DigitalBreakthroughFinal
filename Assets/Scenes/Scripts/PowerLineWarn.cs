using Crosstales.RTVoice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineWarn : MonoBehaviour
{
    public bool isExam;
    public string warning;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<DroneStats>() == null)
            return;
        var droneStats = other.GetComponentInParent<DroneStats>();
        if (droneStats.insidePowerlineZone)
            return;
        droneStats.insidePowerlineZone = true;
        if (isExam)
            return;
        Speaker.Instance.SpeakNative(warning, Speaker.Instance.VoiceForGender(Crosstales.RTVoice.Model.Enum.Gender.FEMALE, "ru-RU", 0, "ru-RU"), 1.3f, 1, 1, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<DroneStats>() == null)
            return;
        var droneStats = other.GetComponentInParent<DroneStats>();
        droneStats.insidePowerlineZone = false;
    }
}

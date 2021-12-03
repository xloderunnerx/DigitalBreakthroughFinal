using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineWarn : MonoBehaviour
{
    
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
        Debug.Log("YOU'RE TOO CLOSE TO THE POWER LINE.");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<DroneStats>() == null)
            return;
        var droneStats = other.GetComponentInParent<DroneStats>();
        droneStats.insidePowerlineZone = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerPlantController : MonoBehaviour
{
    public List<PowerPlantUnit> powerPlantUnits;
    public PowerPlantUnit broken;

    void Start()
    {
        powerPlantUnits = GameObject.FindObjectsOfType<PowerPlantUnit>().ToList();
        broken = powerPlantUnits[Random.Range(0, powerPlantUnits.Count)];
        broken.isBroken = true;
        if(broken._particleSystem != null)
        {
            broken._particleSystem.Play();
        }
    }

    void Update()
    {
        
    }
}

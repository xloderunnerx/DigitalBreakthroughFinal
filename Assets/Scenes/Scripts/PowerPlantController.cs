using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerPlantController : MonoBehaviour
{
    public List<PowerPlantUnit> powerPlantUnits;

    void Start()
    {
        powerPlantUnits = GameObject.FindObjectsOfType<PowerPlantUnit>().ToList();
        powerPlantUnits[Random.Range(0, powerPlantUnits.Count)].isBroken = true;
    }

    void Update()
    {
        
    }
}

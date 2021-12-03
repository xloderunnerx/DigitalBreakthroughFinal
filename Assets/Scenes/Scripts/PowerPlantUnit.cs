using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantUnit : MonoBehaviour
{
    public bool isBroken;
    public ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        
    }

    void Update()
    {
            
    }
}

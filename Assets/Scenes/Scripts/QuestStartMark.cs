using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestStartMark : MonoBehaviour
{
    public bool questTaken;
    public UnityEvent unityEvent;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (questTaken) 
            return;
        if (other.GetComponentInParent<DroneMovement>() == null)
            return;
        unityEvent?.Invoke();
    }
}

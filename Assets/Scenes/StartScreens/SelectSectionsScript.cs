using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSectionsScript : MonoBehaviour
{
    public GameObject currentCanvas;
    public GameObject practiceCanvas;
    public GameObject lectionsCanvas;

    
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void TapToPractice() {
        currentCanvas.SetActive(false);
        practiceCanvas.SetActive(true);
    }

    public void TapToLections() {
        currentCanvas.SetActive(false);
        lectionsCanvas.SetActive(true);
    }
}

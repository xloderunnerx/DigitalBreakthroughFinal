using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScreenScript : MonoBehaviour
{
    public GameObject currentCanvas;
    public GameObject previousCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapToBack()
    {
        currentCanvas.SetActive(false);
        previousCanvas.SetActive(true);
    }

    public void TapToTutorial() {
        currentCanvas.SetActive(false);
    }

    public void TapToTraining() {
        currentCanvas.SetActive(false);
    }

    public void TapToExams() {
        currentCanvas.SetActive(false);
    }

}

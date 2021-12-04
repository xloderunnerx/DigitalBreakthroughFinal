using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetStatistics : MonoBehaviour
{
    public bool isExam;

    public GameObject drone;
    public uint charges;

    public TextMeshProUGUI chargesLabel;
    public TextMeshProUGUI heightDroneLabel;
    public TextMeshProUGUI coordinatesLabel;

    RaycastHit hit;
    float heightAboveGround = 0;

    void Start()
    {
        StartCoroutine(ChangeChargesDrone());
    }

    public IEnumerator ChangeChargesDrone()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            charges -= 1;
            chargesLabel.text = charges.ToString() + "%";
        }
    }

    void Update()
    {
        
        coordinatesLabel.text = drone.transform.position.x + "," + drone.transform.position.y;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(drone.transform.position, drone.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            heightDroneLabel.text = hit.distance.ToString() + "м";
            if (isExam)
                StatisticsExamController.instance.UpdateHeight(hit.distance);
            else StatisticsPracticeController.instance.UpdateHeight(hit.distance);
        }
    }
}

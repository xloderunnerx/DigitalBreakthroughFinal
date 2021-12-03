using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetStatistics : MonoBehaviour
{
    public GameObject drone;
    public int charges;

    public TextMeshProUGUI chargesLabel;
    public TextMeshProUGUI heightDroneLabel;
    public TextMeshProUGUI coordinatesLabel;

    RaycastHit hit;
    float heightAboveGround = 0;

    void Start()
    {
        
    }

    public IEnumerator ChangeChargesDrone()
    {
        yield return new WaitForSeconds(90);
        charges -= 1;
        chargesLabel.text = charges.ToString();
    }

    void Update()
    {
        ChangeChargesDrone();
        coordinatesLabel.text = "Координаты: " + drone.transform.position.x + "," + drone.transform.position.y;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(drone.transform.position, drone.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            heightDroneLabel.text = "Высота: " + hit.distance.ToString() + " м";
        }
    }
}

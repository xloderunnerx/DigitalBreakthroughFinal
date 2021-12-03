using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastPowerUnit : MonoBehaviour
{
    public GameObject buttonHintPrefab;
    public GameObject buttonHint;
    public PowerPlantUnit locked;
    void Start()
    {
        
    }

    void Update()
    {
        if (buttonHint != null)
        {
            buttonHint.transform.LookAt(new Vector3(Camera.main.transform.position.x, buttonHint.transform.position.y, Camera.main.transform.position.z));
        }
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green, 0.1f);
        var hit = new RaycastHit();
        Physics.Raycast(transform.position, transform.forward, out hit, 5);
        if (hit.collider == null)
            return;
        
        if (hit.collider.GetComponentInParent<PowerPlantUnit>() == null)
        {
            locked = null;
            Destroy(buttonHint);
            return;
        }
        var powerUnit = hit.collider.GetComponentInParent<PowerPlantUnit>();
        if(locked != powerUnit)
        {
            locked = null;
            Destroy(buttonHint);
        }
        locked = powerUnit;
        if(buttonHint == null)
        {
            buttonHint = Instantiate(buttonHintPrefab);
            buttonHint.transform.position = powerUnit.transform.position + new Vector3(0, powerUnit.GetComponentInChildren<MeshRenderer>().bounds.size.y * 1.25f, 0);
        }
        
    }
}

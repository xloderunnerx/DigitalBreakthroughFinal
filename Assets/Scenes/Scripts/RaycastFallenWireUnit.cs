using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastFallenWireUnit : MonoBehaviour
{
    public GameObject buttonHintPrefab;
    public GameObject buttonHint;
    public FallenWireUnit locked;
    public string warning;
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
        Physics.Raycast(transform.position, transform.forward, out hit, 10);
        if (hit.collider == null)
            return;

        if (hit.collider.GetComponent<FallenWireUnit>() == null)
        {
            locked = null;
            Destroy(buttonHint);
            return;
        }

        var powerUnit = hit.collider.GetComponent<FallenWireUnit>();

        if (powerUnit.collected)
        {
            locked = null;
            Destroy(buttonHint);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            powerUnit.collected = true;
            StatisticsExamController.instance.UpdateFallenWire();
            StatisticsExamController.instance.SaveData();
            SceneManager.LoadScene(4);
        }

        if (locked != powerUnit)
        {
            locked = null;
            Destroy(buttonHint);
        }
        locked = powerUnit;
        if (buttonHint == null)
        {
            buttonHint = Instantiate(buttonHintPrefab);
            buttonHint.transform.position = powerUnit.transform.position + new Vector3(0, powerUnit.GetComponent<CapsuleCollider>().bounds.size.y * 1.25f, 0);
        }

    }
}

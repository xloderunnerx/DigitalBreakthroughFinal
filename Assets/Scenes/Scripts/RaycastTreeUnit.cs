using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastTreeUnit : MonoBehaviour
{
    public GameObject buttonHintPrefab;
    public GameObject buttonHint;
    public TreeUnit locked;
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
        var hits = Physics.RaycastAll(transform.position, transform.forward, 10);

        if(hits.ToList().Where(h => h.collider.GetComponent<TreeUnit>()).ToList().Count == 0)
        {
            locked = null;
            Destroy(buttonHint);
            return;
        }

        var treeUnit = hits.ToList().Where(h => h.collider.GetComponent<TreeUnit>()).FirstOrDefault().collider.GetComponent<TreeUnit>();

        if (treeUnit.collected)
            return;

        if (treeUnit == null)
        {
            locked = null;
            Destroy(buttonHint);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            treeUnit.collected = true;
            locked = null;
            Destroy(buttonHint);
            return;
        }

        if (locked != treeUnit)
        {
            locked = null;
            Destroy(buttonHint);
        }
        locked = treeUnit;
        if (buttonHint == null)
        {
            buttonHint = Instantiate(buttonHintPrefab);
            
            buttonHint.transform.position = treeUnit.transform.position + (transform.position - treeUnit.transform.position).normalized * treeUnit.GetComponentInChildren<CapsuleCollider>().radius * 1.2f;
        }

    }
}

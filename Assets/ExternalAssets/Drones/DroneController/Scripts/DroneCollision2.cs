using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCollision2 : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public Collider colliderBox;
    public float m_Thrust = 20f;

    Vector3 directionVector = Vector3.right;
    private bool isEnterToZone = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(SwapDirection());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (colliderBox == other) {
            isEnterToZone = true;
        }
    }

    public IEnumerator SwapDirection() {
        yield return new WaitForSeconds(30);
        directionVector = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }

    private void OnTriggerExit(Collider other)
    {
        isEnterToZone = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isEnterToZone)
        {
            Debug.Log(isEnterToZone);
            m_Rigidbody.AddForce(directionVector * m_Thrust);
        }
    }
}

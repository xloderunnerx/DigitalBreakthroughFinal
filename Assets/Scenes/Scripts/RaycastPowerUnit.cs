using Crosstales.RTVoice;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastPowerUnit : MonoBehaviour
{
    public GameObject buttonHintPrefab;
    public GameObject buttonHint;
    public PowerPlantUnit locked;
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
        Physics.Raycast(transform.position, transform.forward, out hit, 5);
        if (hit.collider == null)
            return;
        
        if (hit.collider.GetComponentInParent<PowerPlantUnit>() == null)
        {
            locked = null;
            Destroy(buttonHint);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && !hit.collider.GetComponentInParent<PowerPlantUnit>().isBroken)
        {
            Speaker.Instance.SpeakNative(warning, Speaker.Instance.VoiceForGender(Crosstales.RTVoice.Model.Enum.Gender.FEMALE, "ru-RU", 0, "ru-RU"), 1.3f, 1, 1, true);
            StatisticsPracticeController.instance.UpdateWrongPowerplantUnit();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            StatisticsPracticeController.instance.SaveData();
            SceneManager.LoadScene(5);
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

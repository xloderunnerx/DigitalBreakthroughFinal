using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.RTVoice;

public class CentrerBlockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<DroneMovement>() == null)
        {
            return;
        }
        else {
            Speaker.Instance.SpeakNative("Вы отдалились от зоны маршрута", Speaker.Instance.VoiceForGender(Crosstales.RTVoice.Model.Enum.Gender.FEMALE, "ru-RU", 0, "ru-RU"), 1.3f, 1, 1, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

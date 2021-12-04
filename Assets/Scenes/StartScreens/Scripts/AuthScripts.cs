using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthScripts : MonoBehaviour
{
    public TMP_InputField loginInput;
    public TMP_InputField passwordInput;
    public Toggle showPassword;
    public Button enterButton;
    public GameObject nextCanvas;
    public GameObject currentCanvas;

    string login = "tester@gmail.com";
    string password = "tester"; 

    // Start is called before the first frame update
    void Start()
    {
        showPassword.onValueChanged.AddListener(ValueChanged);
    }

    private void ValueChanged(bool isEnabled)
    {
        if (isEnabled)
        {
            passwordInput.contentType = TMP_InputField.ContentType.Standard;
            passwordInput.ForceLabelUpdate();
        }
        else {
            passwordInput.contentType = TMP_InputField.ContentType.Password;
            passwordInput.ForceLabelUpdate();
        }
    }

    public void Login() 
    {

        if ((passwordInput.text == "") || (loginInput.text == ""))
        {
            Debug.Log("false");
        }
        else if ((passwordInput.text == password) && (loginInput.text == login))
        {
            passwordInput.contentType = TMP_InputField.ContentType.Standard;
            Debug.Log("True");
            currentCanvas.SetActive(false);
            nextCanvas.SetActive(true);
        }

    }
    
    
}

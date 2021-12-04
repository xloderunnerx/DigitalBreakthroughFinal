using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderOnClick : MonoBehaviour
{
    public int sceneIndex;

    private void Awake() => GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(sceneIndex));


}

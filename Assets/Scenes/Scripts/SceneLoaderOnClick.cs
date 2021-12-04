using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderOnClick : MonoBehaviour
{
    public int sceneIndex;

    public void Load() => GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(sceneIndex));
}

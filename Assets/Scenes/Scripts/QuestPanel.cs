using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    public float fadeDuration;
    public float panelTimer;
    public List<Image> except;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init()
    {
        StopAllCoroutines();
        FadeUp();
        StartCoroutine(FadeDownTimer());
    }

    public IEnumerator FadeDownTimer()
    {
        yield return new WaitForSeconds(panelTimer);
        FadeDown();
        gameObject.SetActive(false);
        yield break;
    }

    public void FadeUp()
    {
        GetComponentsInChildren<Image>().ToList().Except(except).ToList().ForEach(i => i.color = new Color(i.color.r, i.color.g, i.color.b, 0));
        GetComponentsInChildren<TextMeshProUGUI>().ToList().ForEach(t => t.color = new Color(t.color.r, t.color.g, t.color.b, 0));
        GetComponentsInChildren<Image>().ToList().Except(except).ToList().ForEach(i => i.DOFade(1, fadeDuration));
        GetComponentsInChildren<TextMeshProUGUI>().ToList().ForEach(t => t.DOFade(1, fadeDuration));
    }

    public void FadeDown()
    {
        GetComponentsInChildren<Image>().ToList().Except(except).ToList().ForEach(i => i.color = new Color(i.color.r, i.color.g, i.color.b, 1));
        GetComponentsInChildren<TextMeshProUGUI>().ToList().ForEach(t => t.color = new Color(t.color.r, t.color.g, t.color.b, 1));
        GetComponentsInChildren<Image>().ToList().Except(except).ToList().ForEach(i => i.DOFade(0, fadeDuration));
        GetComponentsInChildren<TextMeshProUGUI>().ToList().ForEach(t => t.DOFade(0, fadeDuration));
    }
}

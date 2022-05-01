using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    #region Timer

    public int time;
    IEnumerator Corou_Timer()
    {
        yield return new WaitForSeconds(1);
        TimeCounter(1);
    }
    private void TimeCounter(int timeValue = 0)
    {
        StartCoroutine(Corou_Timer());
        time -= timeValue;
    }
    public void StartTimer()
    {
        StartCoroutine(Corou_Timer());
    }
    #endregion

    #region FadeOut/FadeIn

    public GameObject fadeGameObj;
    IEnumerator Corou_Fade(bool FadeOut = true, bool FadeIn = false)
    {
        fadeGameObj.SetActive(true);
        Color imageColor = fadeGameObj.GetComponent<Image>().color;

        if (FadeOut)
        {
            for (float alpha = 1; alpha >= 0; alpha -= .01f)
            {
                imageColor.a = alpha;
                fadeGameObj.GetComponent<Image>().color = imageColor;
                yield return new WaitForSeconds(.01f);
            }

        }
        else if (FadeIn)
        {
            for (float alpha = 0; alpha <= 1; alpha += .01f)
            {
                imageColor.a = alpha;
                fadeGameObj.GetComponent<Image>().color = imageColor;
                yield return new WaitForSeconds(.01f);
            }

        }
        fadeGameObj.SetActive(false);

    }

    public void StartFade(bool FadeOut = true, bool FadeIn = false)
    {
        if(fadeGameObj.activeSelf == false)
        {
            StartCoroutine(Corou_Fade(FadeOut, FadeIn));
        }
    }
    #endregion
}

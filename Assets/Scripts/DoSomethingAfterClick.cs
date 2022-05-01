using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoSomethingAfterClick : MonoBehaviour
{
    public HudManager hudManager;
    public TMP_Text tmpText;
    public string nextScene;

    private bool changeSceneSwitch = false;

    private void Start()
    {
        hudManager.StartFade(true,false);
    }
    private void Update()
    {
        if (changeSceneSwitch)
        {
            tmpText.text = "Change scene in... " + hudManager.time.ToString();
            if (hudManager.time == 0)
            {
                hudManager.StartFade(false, true);
                Invoke("LoadScene", 1);
            }
        }
    }

    public void ChangeText(string text)
    {
        tmpText.text = text;
        Invoke("ChangeScene", 2);
    }
    public void ChangeScene()
    {
        changeSceneSwitch = true;
        hudManager.StartTimer();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

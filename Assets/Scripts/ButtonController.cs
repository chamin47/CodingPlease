using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}

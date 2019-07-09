using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerCustom : MonoBehaviour
{
    public void train()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void quit()
    {
        Application.Quit();
    }
}

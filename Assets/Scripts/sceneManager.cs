using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void about()
    {
        SceneManager.LoadScene(6);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

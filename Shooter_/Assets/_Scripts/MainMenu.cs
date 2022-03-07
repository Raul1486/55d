using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Button Empezar;


    public void Inicio()
    {
        SceneManager.LoadScene("Level_1");
    }
}

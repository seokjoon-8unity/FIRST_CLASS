using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadImageMainButton : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadImageExitButton : MonoBehaviour
{
    public void OnclickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

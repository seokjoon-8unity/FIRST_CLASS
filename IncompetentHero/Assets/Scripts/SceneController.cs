using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void SwitchScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void CutScene1End() // 컷씬 1 끝나면 스테이지 셀렉트 화면으로
    {
        SceneManager.LoadScene("StageSelect");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneController : MonoBehaviour
{
    public PlayableDirector director;

    void Update()
    {
        // 키보드 엔터 키를 누르면 타임라인을 스킵합니다.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SkipTimeline();
        }
    }

    public void SkipTimeline()
    {
        director.time = director.duration; // 타임라인의 끝으로 이동하면 스킵됩니다.
    }

    public void GoToSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void EndingToStartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

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
        // Ű���� ���� Ű�� ������ Ÿ�Ӷ����� ��ŵ�մϴ�.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SkipTimeline();
        }
    }

    public void SkipTimeline()
    {
        director.time = director.duration; // Ÿ�Ӷ����� ������ �̵��ϸ� ��ŵ�˴ϴ�.
    }

    public void GoToSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void EndingToStartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Ending()
    {
        SceneManager.LoadScene("CutScene_Ending");
    }

    public void GoToStage()
    {
        SceneManager.LoadScene("MainScene");
    }

}

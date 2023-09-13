using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject player;

    float minX = -5f; // x 좌표의 최소값
    float maxX = 13f; // x 좌표의 최대값

    public void SelectRightStage()
    {

        /*
         * KimHyungSu
         */
        StageManager.Instance.StageUp();
        //

        // 현재 위치에서 오른쪽으로 이동
        float newX = player.transform.position.x + 6f;

        // x 좌표가 최대값을 넘지 않도록 제한
        newX = Mathf.Min(newX, maxX);

        // 새로운 위치 설정
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void SelectLeftStage()
    {

        /*
         * KimHyungSu
         */
        StageManager.Instance.StageDown();
        //

        // 현재 위치에서 왼쪽으로 이동
        float newX = player.transform.position.x - 6f;

        // x 좌표가 최소값을 넘지 않도록 제한
        newX = Mathf.Max(newX, minX);

        // 새로운 위치 설정
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    /*
     * KimHyungSu
     */
    public void SelectStartStage()
    {
        int stage = StageManager.Instance.GetStage();

        switch (stage)
        {
            case 1:
                //Debug.Log("SelectStartStage() case 1 호출");
                SceneManager.LoadScene("Stage1");
                break;

            case 2:
                //Debug.Log("SelectStartStage() case 2 호출");
                SceneManager.LoadScene("Stage2");
                break;

            case 3:
                //Debug.Log("SelectStartStage() case 3 호출");
                SceneManager.LoadScene("Stage3");
                break;

            case 4:
                //Debug.Log("SelectStartStage() case 4 호출");
                SceneManager.LoadScene("Stage4");
                break;

            default:
                Debug.Log("SelectStartStage() default 호출");
                break;
        }
    }
    //
}

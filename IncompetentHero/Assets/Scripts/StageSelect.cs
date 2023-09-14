using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject player;

    int minStage = 1;
    int maxStage = 4;

    public void SelectRightStage()
    {
        ref int stg = ref SoundManager.GetInstance().Stage;

        stg += 1;
        stg = Mathf.Min(stg, maxStage);

        float newX = (float)6 * (stg - 1) - 5;

        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void SelectLeftStage()
    {
        ref int stg = ref SoundManager.GetInstance().Stage;

        stg -= 1;
        stg = Mathf.Max(stg, minStage);

        float newX = (float)6 * (stg - 1) - 5;

        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void Join() {
        switch(SoundManager.GetInstance().Stage) {
            case 1:
            case 2:
                SceneManager.LoadScene("MainScene");
                break;
            case 3:
                SceneManager.LoadScene("CutScene_Stage3_Before");
                break;
            case 4:
                SceneManager.LoadScene("CutScene_Stage4_Before");
                break;
            
        }
    }
}

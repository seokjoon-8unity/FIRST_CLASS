using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject player;

    int minStage = 1;
    int maxStage = 4;

    int _stage = 1;

    public void SelectRightStage()
    {
        _stage += 1;
        _stage = Mathf.Min(_stage, maxStage);

        float newX = (float)6 * (_stage - 1) - 5;

        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void SelectLeftStage()
    {
        _stage -= 1;
        _stage = Mathf.Max(_stage, minStage);

        float newX = (float)6 * (_stage - 1) - 5;

        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }
}

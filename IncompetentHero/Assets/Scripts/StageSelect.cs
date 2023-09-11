using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject player;

    float minX = -5f; // x 좌표의 최소값
    float maxX = 13f; // x 좌표의 최대값

    public void SelectRightStage()
    {
        // 현재 위치에서 오른쪽으로 이동
        float newX = player.transform.position.x + 6f;

        // x 좌표가 최대값을 넘지 않도록 제한
        newX = Mathf.Min(newX, maxX);

        // 새로운 위치 설정
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void SelectLeftStage()
    {
        // 현재 위치에서 왼쪽으로 이동
        float newX = player.transform.position.x - 6f;

        // x 좌표가 최소값을 넘지 않도록 제한
        newX = Mathf.Max(newX, minX);

        // 새로운 위치 설정
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }
}

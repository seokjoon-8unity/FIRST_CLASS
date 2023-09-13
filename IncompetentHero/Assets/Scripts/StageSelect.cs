using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject player;

    float minX = -5f; // x ��ǥ�� �ּҰ�
    float maxX = 13f; // x ��ǥ�� �ִ밪

    /*
     * KimHyungSu
     */
    [SerializeField]
    private int stage;

    [SerializeField] private int minStage;
    [SerializeField] private int maxStage;
    //

    public void SelectRightStage()
    {
        // ���� ��ġ���� ���������� �̵�
        float newX = player.transform.position.x + 6f;

        // x ��ǥ�� �ִ밪�� ���� �ʵ��� ����
        newX = Mathf.Min(newX, maxX);

        // ���ο� ��ġ ����
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void SelectLeftStage()
    {
        // ���� ��ġ���� �������� �̵�
        float newX = player.transform.position.x - 6f;

        // x ��ǥ�� �ּҰ��� ���� �ʵ��� ����
        newX = Mathf.Max(newX, minX);

        // ���ο� ��ġ ����
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    /*
     * KimHyungSu
     */
    private void StageUp()
    {
        stage++;
    }
    //
}

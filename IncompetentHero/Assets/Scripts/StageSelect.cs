using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject player;

    float minX = -5f; // x ��ǥ�� �ּҰ�
    float maxX = 13f; // x ��ǥ�� �ִ밪

    public void SelectRightStage()
    {

        /*
         * KimHyungSu
         */
        StageManager.Instance.StageUp();
        //

        // ���� ��ġ���� ���������� �̵�
        float newX = player.transform.position.x + 6f;

        // x ��ǥ�� �ִ밪�� ���� �ʵ��� ����
        newX = Mathf.Min(newX, maxX);

        // ���ο� ��ġ ����
        player.transform.position = new Vector3(newX, player.transform.position.y, 0);
    }

    public void SelectLeftStage()
    {

        /*
         * KimHyungSu
         */
        StageManager.Instance.StageDown();
        //

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
    public void SelectStartStage()
    {
        int stage = StageManager.Instance.GetStage();

        switch (stage)
        {
            case 1:
                //Debug.Log("SelectStartStage() case 1 ȣ��");
                SceneManager.LoadScene("Stage1");
                break;

            case 2:
                //Debug.Log("SelectStartStage() case 2 ȣ��");
                SceneManager.LoadScene("Stage2");
                break;

            case 3:
                //Debug.Log("SelectStartStage() case 3 ȣ��");
                SceneManager.LoadScene("Stage3");
                break;

            case 4:
                //Debug.Log("SelectStartStage() case 4 ȣ��");
                SceneManager.LoadScene("Stage4");
                break;

            default:
                Debug.Log("SelectStartStage() default ȣ��");
                break;
        }
    }
    //
}

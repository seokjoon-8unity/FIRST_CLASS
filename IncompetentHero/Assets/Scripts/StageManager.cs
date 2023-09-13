/*
 * KimHyungSu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // �� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �͸� �����ϰ� �� ���̴�.
    private static StageManager instance = null;

    [SerializeField]
    private int stage = 1;

    [SerializeField] private int minStage;
    [SerializeField] private int maxStage;

    void Awake()
    {
        if (null == instance)
        {
            // �� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            // �� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            // �򰥸� ������ ���� this�� �ٿ��ش�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // �� �̵��� �Ǿ��µ� �� ������ �̱����� �Ŵ����� ������ ���� �ִ�.
            // �̹� ���������� I�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� �̱����� �Ŵ���)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    // �̱����� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ.
    public static StageManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }

            return instance;
        }
    }

    void Start()
    {
        
    }

    
    public int GetStage()
    {
        return stage;
    }

    public void StageUp()
    {
        stage++;

        stage = Mathf.Clamp(stage, minStage, maxStage);

        //Debug.Log(stage);
    }

    public void StageDown()
    {
        stage--;

        stage = Mathf.Clamp(stage, minStage, maxStage);

        //Debug.Log(stage);
    }
    
}

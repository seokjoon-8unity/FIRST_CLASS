/*
 * KimHyungSu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // 이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 것만 존재하게 할 것이다.
    private static StageManager instance = null;

    [SerializeField]
    private int stage = 1;

    [SerializeField] private int minStage;
    [SerializeField] private int maxStage;

    void Awake()
    {
        if (null == instance)
        {
            // 이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            // 씬 전환이 되더라도 파괴되지 않게 한다.
            // 헷갈림 방지를 위해 this를 붙여준다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 씬 이동이 되었는데 그 씬에도 싱글톤인 매니저가 존재할 수도 있다.
            // 이미 전역변수인 I에 인스턴스가 존재한다면 자신(새로운 씬의 싱글톤인 매니저)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    // 싱글톤인 매니저 인스턴스에 접근할 수 있는 프로퍼티.
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

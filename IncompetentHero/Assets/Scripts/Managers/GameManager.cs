using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
        	//@Managers 가 존재하는지 확인
        	GameObject go = GameObject.Find("GameManager");
            //없으면 생성
            if(go == null)
            {
            	go = new GameObject { name = "GameManager" };
            }
            if(go.GetComponent<GameManager>() == null)
            {
            	go.AddComponent<GameManager>();
            }

            //DontDestroyOnLoad(go);
            
            //instance 할당
            _instance = go.GetComponent<GameManager>();
        }

        return _instance;
    }

    public PoolManager PoolManager;

    public int HP;
    public StageName Stage;
}
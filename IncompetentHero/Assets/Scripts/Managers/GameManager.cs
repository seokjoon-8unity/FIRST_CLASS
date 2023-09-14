using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
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
    public BuffManager BuffManager;
    public Player Player;

    public int HP;
    public float GameTime;
    public float MaxTime;
    public StageName Stage;
    [SerializeField] private List<GameObject> _maps;

    private void Awake() {
        Init();
    }

    void Init() {
        HP = 3;
        MaxTime = 60;
        GameTime = MaxTime;
        Stage = (StageName)(SoundManager.GetInstance().Stage);

        _maps[(int)Stage].SetActive(true);
    }

    void Update() {
        GameTime -= Time.deltaTime;
        if(GameTime <= 0) {
            // 게임 성공
            ClearGame();
        }
    }

    public void ChangeHP(int hp) {
        HP += hp;

        if(HP <= 0) {
            // 게임 실패
            SceneManager.LoadScene("DeadImage");
        }
    }

    void ClearGame() {
        switch(Stage) {
            case StageName.PLAIN:
                SceneManager.LoadScene("CutScene_Stage1");
                break;
            case StageName.RIFT:
                SceneManager.LoadScene("CutScene_Stage2");
                break;
            case StageName.SPACE:
                SceneManager.LoadScene("CutScene_Stage3_After");
                break;
            case StageName.CASTLE:
                SceneManager.LoadScene("CutScene_Stage4_After");
                break;
        }
    }
}
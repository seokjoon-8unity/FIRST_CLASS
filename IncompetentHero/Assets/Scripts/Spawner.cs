using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTerm;
    private float _timer;

    [SerializeField] private float _rangeX = 2.5f;
    [SerializeField] private float _posY = 5;



    void Start() {
        // 현재 스테이지에 따라 스폰 주기 조절
        switch(GameManager.GetInstance().Stage) {
            case StageName.SLIMENEST:
                _spawnTerm = 0.7f;
                break;
            case StageName.BLABLADESART:
                _spawnTerm = 0.5f;
                break;
            case StageName.FORGOTTENFOREST:
                _spawnTerm = 0.3f;
                break;
        }
    }

    void Update() {
        _timer += Time.deltaTime;

        if(_timer >= _spawnTerm) {
            Spawn();
            _timer = 0;
        }
    }

    // 객체 생성은 사실상 PoolManager의 함수에서 됨, 여기서는 그 함수를 실행하고 위치 세팅하는 역할만 함
    void Spawn() {
        GameObject go;

        // 0이 enemy긴 한데.. enemy 프리팹 하나만 두고 SO로 데이터 꽂는 방식으로 하길 희망.....
        go = GameManager.GetInstance().PoolManager.GetItemWithIndex(0);

        go.transform.position = new Vector3(Random.Range(-_rangeX, _rangeX), _posY, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTerm;
    private float _timer;

    [SerializeField] private float _rangeX = 2.5f;
    [SerializeField] private float _posY = 5;

    [SerializeField] private List<FallableSO> _enemies;
    [SerializeField] private List<FallableSO> _items;


    void Start() {
        // 현재 스테이지에 따라 스폰 주기 조절
        switch(GameManager.GetInstance().Stage) {
            case StageName.PLAIN:
                _spawnTerm = 0.7f;
                break;
            case StageName.GRAVE:
                _spawnTerm = 0.5f;
                break;
            case StageName.SPACE:
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

        // 80%로 몬스터, 20%로 아이템 생성
        if(Random.Range(0, 100) < 80) {
            go = GameManager.GetInstance().PoolManager.GetItemWithIndex(0);
            go.GetComponent<Fallable>().Init(GetDataWithStage(true));
        }
        else {
            go = GameManager.GetInstance().PoolManager.GetItemWithIndex(1);
            go.GetComponent<Fallable>().Init(GetDataWithStage(false));
        }
        
        go.transform.parent = gameObject.transform;
        go.transform.position = new Vector3(Random.Range(-_rangeX, _rangeX), _posY, 0);
    }

    FallableSO GetDataWithStage(bool enemy) {
        switch(GameManager.GetInstance().Stage) {
            case StageName.PLAIN:
                if(enemy) return _enemies[Random.Range(0, 4)];
                else return _items[Random.Range(0, 4)];
            case StageName.GRAVE:
                if(enemy) return _enemies[Random.Range(0, 1)];
                else return _items[Random.Range(0, 4)];
            case StageName.SPACE:
                if(enemy) return _enemies[Random.Range(0, 1)];
                else return _items[Random.Range(0, 4)];
        }

        return null;
    }
}

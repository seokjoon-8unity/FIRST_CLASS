using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Prefabs;

    private List<GameObject>[] _pools;

    private void Awake() {
        _pools = new List<GameObject>[Prefabs.Length];

        for (int i = 0; i < _pools.Length; i++) {
            _pools[i] = new List<GameObject>();
        }
    }

    // 스폰할 타입에 맞춰 기존에 생성했지만 사용하지 않는 객체가 있나 찾아주고, 없다면 만들어서 주는 함수
    public GameObject GetItemWithIndex(SpawnType type) {
        GameObject select = null;

        foreach (var item in _pools[(int)type]) {
            if(!item.activeSelf) {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select) {
            select = Instantiate(Prefabs[(int)type]);
            _pools[(int)type].Add(select);
        }

        return select;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    // 모든 버프(SO) 다 올려둠
    [SerializeField] private List<BuffSO> BuffPool;
    public bool[] InUse;

    private void Start() {
        Init();
    }

    void Init() {
        InUse = new bool[BuffPool.Count];
    }

    public void TakeBuff(BuffType buffType) {
        BuffSO buff = BuffPool[(int)buffType];

        if(InUse[(int)buffType]) {
            buff.AddTick();
        }
        else {
            StartCoroutine(buff.AffectBuff());
        }
    }

    public BuffSO GetBuffSO(int index) {
        return BuffPool[index];
    }
}

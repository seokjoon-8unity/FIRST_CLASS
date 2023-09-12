using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    // 모든 버프(SO) 다 올려둠
    [SerializeField] private List<BuffSO> BuffPool;
    private float[] BuffRemainTime;

    private void Start() {
        BuffRemainTime = new float[BuffPool.Count];
    }

    public void TakeBuff(BuffType buffType) {
        BuffSO buff = BuffPool[(int)buffType];
        

        StartCoroutine(buff.AffectBuff());
    }
}

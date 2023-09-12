using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    // 모든 버프(SO) 다 올려둠
    public List<BuffSO> BuffPool;

    public void TakeBuff(BuffName buffName) {
        BuffSO buff = BuffPool[(int)buffName];

        StartCoroutine(buff.AffectBuff());
    }
}

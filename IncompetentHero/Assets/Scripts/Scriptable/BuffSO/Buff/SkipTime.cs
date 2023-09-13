using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkipTime", menuName = "Scriptable Object/Buffs/SkipTime")]
public class SkipTime : BuffSO
{
    [SerializeField] private float skipAmount;

    public override IEnumerator AffectBuff()
    {
        GameManager.GetInstance().GameTime -= skipAmount;
        yield return null;
    }
}

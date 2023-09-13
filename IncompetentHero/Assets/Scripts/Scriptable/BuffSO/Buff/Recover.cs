using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recover", menuName = "Scriptable Object/Buffs/Recover")]
public class Recover : BuffSO
{
    [SerializeField] private int RecoveryAmount;

    public override IEnumerator AffectBuff()
    {
        GameManager.GetInstance().BuffManager.InUse[(int)BuffType.RECOVERY] = true;

        GameManager.GetInstance().HP += RecoveryAmount;
        yield return null;

        GameManager.GetInstance().BuffManager.InUse[(int)BuffType.RECOVERY] = false;
    }
}

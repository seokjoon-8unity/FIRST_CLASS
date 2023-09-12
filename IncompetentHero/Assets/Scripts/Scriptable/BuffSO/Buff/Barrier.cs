using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Barrier", menuName = "Scriptable Object/Buffs/Barrier")]
public class Barrier : BuffSO
{
    public override IEnumerator AffectBuff()
    {
        float remainTime = buffDuration;

        ApplyBarrier();

        while (remainTime > 0) {
            remainTime -= 1;
            yield return new WaitForSeconds(1);
        }

        RemoveBarrier();
    }

    private void ApplyBarrier()
    {
        //GameManager.GetInstance().Player.moveSpeed += fastAmount;
    }

    private void RemoveBarrier()
    {
        //GameManager.GetInstance().Player.moveSpeed = originalSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUp", menuName = "Scriptable Object/Buffs/SpeedUp")]
public class SpeedUp : BuffSO
{
    [SerializeField] private float fastAmount;

    private float originalSpeed;

    public override IEnumerator AffectBuff()
    {
        GameManager.GetInstance().BuffManager.InUse[(int)BuffType.SPEEDUP] = true;
        buffTick = buffDuration;

        originalSpeed = GameManager.GetInstance().Player.speed;

        ApplyFast();

        while (buffTick > 0) {
            buffTick -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        RemoveFast();
        GameManager.GetInstance().BuffManager.InUse[(int)BuffType.SPEEDUP] = false;
    }

    private void ApplyFast()
    {
        GameManager.GetInstance().Player.speed += fastAmount;
    }

    private void RemoveFast()
    {
        GameManager.GetInstance().Player.speed = originalSpeed;
    }
}

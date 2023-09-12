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
        float remainTime = buffDuration;
        originalSpeed = GameManager.GetInstance().Player.speed;

        ApplyFast();

        while (remainTime > 0) {
            remainTime -= 1;
            yield return new WaitForSeconds(1);
        }

        RemoveFast();
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

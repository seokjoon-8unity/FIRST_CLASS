using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Barrier", menuName = "Scriptable Object/Buffs/Barrier")]
public class Barrier : BuffSO
{
    private GameObject _barrier;
    private Vector3 _offset = new Vector3(0, 1, 0);
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
        _barrier = GameManager.GetInstance().PoolManager.GetItemWithIndex(3);

        // 보호막 위치 조정
        _barrier.transform.position = GameManager.GetInstance().Player.gameObject.transform.position + _offset;
        // 플레이어 따라 움직이도록 플레이어의 자식으로 추가
        _barrier.transform.parent = GameManager.GetInstance().Player.transform;
    }

    private void RemoveBarrier()
    {
        _barrier.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fallable
{
    protected Animator _anim;
    [SerializeField] protected RuntimeAnimatorController[] _animCon;

    private void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    public override void Init(FallableSO data) {
        _anim.runtimeAnimatorController = _animCon[data.ID];
    }
    private void OnEnable() {
        _rigid.isKinematic = false;
        _anim.SetBool("IsDead", false);
    }    
    
    protected override void PlayerTrigger() {
        GameManager.GetInstance().ChangeHP(-1);
        GameManager.GetInstance().Player.SetHitTrigger();

        _rigid.isKinematic = true;
        _rigid.velocity = Vector3.zero;
        _anim.SetBool("IsDead", true);

        Invoke("SetActiveFalse", 0.3f);
    }

    protected override void GroundTrigger() {
        _rigid.isKinematic = true;
        _rigid.velocity = Vector3.zero;
        _anim.SetBool("IsDead", true);

        Invoke("SetActiveFalse", 0.3f);
    }

    protected override void BarrierTrigger() {
        _rigid.isKinematic = true;
        _rigid.velocity = Vector3.zero;
        _anim.SetBool("IsDead", true);

        Invoke("SetActiveFalse", 0.3f);
    }

    void SetActiveFalse() {
        gameObject.SetActive(false);
    }
}

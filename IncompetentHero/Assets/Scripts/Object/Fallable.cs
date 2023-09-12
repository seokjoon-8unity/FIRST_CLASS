using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fallable : MonoBehaviour
{

    protected Rigidbody2D _rigid;
    protected Animator _anim;
    
    [SerializeField] protected RuntimeAnimatorController[] _animCon;
    
    private void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }
    public void Init(FallableSO data) {
        _anim.runtimeAnimatorController = _animCon[data.ID];
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            PlayerTrigger();
            
            ShowDeathAnim();
            Invoke("SetActiveFalse", 0.3f);
        }
        if(other.gameObject.CompareTag("Ground")) {
            GroundTrigger();
            
            ShowDeathAnim();
            Invoke("SetActiveFalse", 0.3f);
        }
        
        
    }

    protected abstract void PlayerTrigger();
    protected void GroundTrigger() { }

    void ShowDeathAnim() {
        _rigid.isKinematic = true;
        _rigid.velocity = new Vector3(0, 0, 0);
        _anim.SetBool("IsDead", true);
    }

    void SetActiveFalse() {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        _rigid.isKinematic = false;
        _anim.SetBool("IsDead", false);
    }
}

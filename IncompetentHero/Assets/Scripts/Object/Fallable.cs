using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fallable : MonoBehaviour
{
    protected Rigidbody2D _rigid;
    [SerializeField] protected AudioClip[] _clips;
    protected AudioClip _hitSFX;

    protected void OnTriggerEnter2D(Collider2D other) {
        SoundManager.GetInstance().PlaySFX(_hitSFX);

        if(other.gameObject.CompareTag("Player")) {
            PlayerTrigger();
        }
        if(other.gameObject.CompareTag("Ground")) {
            GroundTrigger();
        }
        if(other.gameObject.CompareTag("Barrier")) {
            BarrierTrigger();
        }
    }
    
    public abstract void Init(FallableSO data);
    protected abstract void PlayerTrigger();
    protected abstract void GroundTrigger();
    protected abstract void BarrierTrigger();
}

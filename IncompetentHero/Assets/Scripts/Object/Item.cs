using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Fallable
{
    protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected Sprite[] _sprites;
    private BuffType type;
    
    private void Awake() {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Init(FallableSO data) {
        _spriteRenderer.sprite = _sprites[data.ID];
        type = (BuffType)data.ID;
    }

    protected override void PlayerTrigger() {
        GameManager.GetInstance().BuffManager.TakeBuff(type);

        gameObject.SetActive(false);
    }
    protected override void GroundTrigger() {
        gameObject.SetActive(false);
    }

    protected override void BarrierTrigger() {
        GameManager.GetInstance().BuffManager.TakeBuff(type);
        
        gameObject.SetActive(false);
    }
}

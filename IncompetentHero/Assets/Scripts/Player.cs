using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator _anim;
    [SerializeField] protected RuntimeAnimatorController[] _animCon;
    private SpriteRenderer _spriteRenderer;

    private Vector2 moveVector = Vector2.zero;

    private void Awake() {
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        switch(GameManager.GetInstance().Stage) {
            case StageName.PLAIN:
            case StageName.RIFT:
            case StageName.CASTLE:
                _anim.runtimeAnimatorController = _animCon[0];
                break;
            case StageName.SPACE:
                _anim.runtimeAnimatorController = _animCon[1];
                break;
        }
        
    }

    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");

        //Debug.Log("moveVector: " + moveVector);
    }

    private void Move()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);

        SetSpriteFilp();

        ConstrainToCameraBounds();
    }

    /// <summary>
    /// ī�޶� ��� ������ �÷��̾ �� ������ �Ѵ�.
    /// </summary>
    private void ConstrainToCameraBounds()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0f)
        {
            viewPos.x = 0f;
        }

        if (viewPos.x > 1f)
        {
            viewPos.x = 1f;
        }

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    private void SetSpriteFilp()
    {
        if (moveVector.x == 1)
        {
            _spriteRenderer.flipX = false;
        }

        if (moveVector.x == -1)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void SetHitTrigger() {
        _anim.SetTrigger("HitTrigger");
    }
}
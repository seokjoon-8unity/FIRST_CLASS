using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemySO _enemySO;
    public EnemySO EnemySO { set { _enemySO = value; } }

    private string _name;
    private SpriteRenderer _sprite;
    private Animator _anim;

    private void OnEnable() {
        _name = _enemySO.EnemyName;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.GetInstance().HP--;
            gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Ground")) {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemySO _enemySO;
    public EnemySO EnemySO { set { _enemySO = value; } }

    private SpriteRenderer _sprite;
    private Animator _anim;

    private void OnEnable() {
        
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

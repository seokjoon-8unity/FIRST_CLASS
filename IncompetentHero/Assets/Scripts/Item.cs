using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private BuffType type;
    private SpriteRenderer _sprite;
    private Animator _anim;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            GameManager.GetInstance().BuffManager.TakeBuff(type);
            gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Ground")) {
            gameObject.SetActive(false);
        }
    }
}

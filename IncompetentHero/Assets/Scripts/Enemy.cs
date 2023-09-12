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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        //if (collision.gameObject.tag == "Ground")
        //{
        //    Destroy(gameObject);
        //}
    }
}

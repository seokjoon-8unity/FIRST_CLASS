using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    //private Vector2 moveDirection = Vector2.zero;

    private Vector2 moveVector = Vector2.zero;

    void Start()
    {
        
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
    }
}

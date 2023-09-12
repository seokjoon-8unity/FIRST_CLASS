using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fallable
{
    protected override void PlayerTrigger() {
        GameManager.GetInstance().HP -= 1;
    }
            
}

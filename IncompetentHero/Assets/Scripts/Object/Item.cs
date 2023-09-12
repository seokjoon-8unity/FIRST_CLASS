using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Fallable
{
    [SerializeField] private BuffType type;
    
    protected override void PlayerTrigger() {
        GameManager.GetInstance().BuffManager.TakeBuff(type);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Object/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    private string _itemName;
    public string ItemName { get { return _itemName; } }
    
    [SerializeField]
    private int _spriteType;
    public int SpriteType { get { return _spriteType; } }
}

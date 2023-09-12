using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Object/EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField]
    private string _enemyName;
    public string EnemyName { get { return _enemyName; } }
    
    [SerializeField]
    private int _spriteType;
    public int SpriteType { get { return _spriteType; } }

    [SerializeField]
    private StageName _stage;
    public StageName Stage { get { return _stage; } }
}

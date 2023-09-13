using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffSO : ScriptableObject
{
    [field: SerializeField] public float buffDuration { get; set; }
    [field: SerializeField] public string buffName { get; set; }
    [field: SerializeField][field: TextArea] public string buffDescription { get; set; }
    public abstract IEnumerator AffectBuff();
}

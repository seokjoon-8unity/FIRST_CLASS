using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FallableSO", menuName = "Scriptable Object/FallableSO")]
public class FallableSO : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }
    
    [SerializeField]
    private int _id;
    public int ID { get { return _id; } }

    [SerializeField]
    private StageName _stage;
    public StageName Stage { get { return _stage; } }
}

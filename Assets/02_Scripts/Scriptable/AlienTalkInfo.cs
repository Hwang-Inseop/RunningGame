using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AlienTalkInfo", menuName = "Scriptable Object/AlienTalkInfo", order = int.MaxValue)]

public class AlienTalkInfo : ScriptableObject
{
    //에일리언이 말하는 말 
    [SerializeField]
    private string talk;

    public string Talk { get { return talk; } }

}

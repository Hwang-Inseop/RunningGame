using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningGame.Scriptable
{
    [CreateAssetMenu(fileName = "PatternDatas", menuName = "ScriptableObjects/PatternDatas", order = 1)]
    public class PatternDatas : ScriptableObject
    {
        [Header("01. Castle Stage")]
        [SerializeField] private List<GameObject> patterns_01 = new();
        [Header("02. Mushroom Stage")]
        [SerializeField] private List<GameObject> patterns_02 = new();
        [Header("03. Candy Stage")]
        [SerializeField] private List<GameObject> patterns_03 = new();
        
        public List<GameObject> GetPatternList(int stage)
        {
            switch (stage)
            {
                case 1:
                    return patterns_01;
                case 2:
                    return patterns_02;
                case 3:
                    return patterns_03;
                default:
                    return null;
            }
        }
    }
}
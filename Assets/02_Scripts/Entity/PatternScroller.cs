using System;
using RunningGame.Managers;
using UnityEngine;

namespace RunningGame.Entity
{
    public class PatternScroller : MonoBehaviour
    {
        [SerializeField] private Transform tr;
        
        private const float acceleration = 0.2f;
        private const float scrollSpeed = 5f;
        
        private Vector3 offset = Vector3.zero;
        private float timeElapsed;
        private bool isStart;

        private void Start()
        {
            MainSceneBase.Instance.AddGameStartListener(() => isStart = true);
        }

        private void Update()
        {
            if (!isStart) return;
            
            timeElapsed += Time.deltaTime;
            var speedMultiplier = 1f + acceleration * Mathf.Log(1f + timeElapsed);
            offset = new Vector3(Time.deltaTime * (scrollSpeed * speedMultiplier), 0, 0);
            tr.position -= offset;
        }
    }
}
using System;
using RunningGame.Managers;
using RunningGame.Utils;
using UnityEngine;

namespace RunningGame.Entity
{
    public class PatternScroller : MonoBehaviour
    {
        [SerializeField] private Transform tr;
        
        private const float acceleration = 0.1f;
        
        private Vector3 offset = Vector3.zero;
        private float scrollSpeed = Define.BaseScrollSpeed;
        private float timeElapsed;
        private bool isStart;

        private void Update()
        {
            if (!isStart) return;
            
            timeElapsed += Time.deltaTime;
            var speedMultiplier = 1f + acceleration * Mathf.Log(1f + timeElapsed);
            offset = new Vector3(Time.deltaTime * (scrollSpeed * speedMultiplier), 0, 0);
            tr.position -= offset;
        }

        public void Init()
        {
            timeElapsed = 0f;
            tr.position = Vector3.zero;
            isStart = true;
        }
    }
}
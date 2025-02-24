using System;
using UnityEngine;

namespace RunningGame.Entity
{
    public class PatternScroller : MonoBehaviour
    {
        [SerializeField] private Transform tr;
        private float scrollSpeed = 5f;
        private float acceleration = 0.2f;
        private float timeElapsed = 0f;
        private Vector3 offset = Vector3.zero;

        public float x;

        private void Update()
        {
            timeElapsed += Time.deltaTime;
            var speedMultiplier = 1f + acceleration * Mathf.Log(1f + timeElapsed);
            
            x = Time.deltaTime * (scrollSpeed * speedMultiplier); // test
            
            offset = new Vector3(Time.deltaTime * (scrollSpeed * speedMultiplier), 0, 0);
            tr.position -= offset;
        }

        public void OnGUI()
        {
            var style = new GUIStyle();
            style.fontSize = 15;
            style.normal.textColor = Color.black;
            
            GUI.Label(new Rect(10, 10, 100, 20), "Scroll Speed", style);
            scrollSpeed = GUI.HorizontalSlider(new Rect(10, 30, 100, 20), scrollSpeed, scrollSpeed, 20f);
        }
    }
}
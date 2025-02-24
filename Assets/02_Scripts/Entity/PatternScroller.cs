using System;
using UnityEngine;

namespace RunningGame.Entity
{
    public class PatternScroller : MonoBehaviour
    {
        [SerializeField] private Transform tr;
        public float scrollSpeed { get; private set; } = 5f;

        private void Update()
        {
            var x = Time.deltaTime * scrollSpeed;
            var offset = new Vector3(x, 0, 0);
            tr.position -= offset;
        }

        public void OnGUI()
        {
            var style = new GUIStyle();
            style.fontSize = 15;
            style.normal.textColor = Color.black;
            
            GUI.Label(new Rect(10, 10, 100, 20), "Scroll Speed", style);
            scrollSpeed = GUI.HorizontalSlider(new Rect(10, 30, 100, 20), scrollSpeed, 1f, 10f);
        }
    }
}
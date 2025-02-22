using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningGame.Singleton
{
    // T는 반드시 MonoBehaviour를 상속받은 클래스여야 한다.
    public abstract class SceneSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance => instance ? instance : null;

        private void Awake()
        {
            // 이미 존재하는 싱글턴이 있으면 중복 생성하지 않는다.
            if (instance != null && instance != this)
            {
                Debug.LogWarning($"{typeof(T)} 싱글턴이 이미 존재합니다. 중복된 인스턴스를 삭제합니다.");
                Destroy(gameObject);
                return;
            }

            // 현재 인스턴스를 정적 변수에 할당한다.
            instance = this as T;
        }

        // 씬 언로드 시 이전 객체의 instance를 참조하지 않도록 null 처리한다.
        private void OnDestroy()
        {
            instance = null;
        }

        public abstract void Init();
    }
}
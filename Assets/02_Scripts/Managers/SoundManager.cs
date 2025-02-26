using RunningGame.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningGame.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource sfxSource;
        
        public static SoundManager Instance { get; private set; }
        private readonly Dictionary<string, AudioClip> audioClips = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Init()
        {
            var mainCam = Camera.main;
            if (mainCam == null)
            {
                Debug.LogError("SoundManager : Camera.main이 존재하지 않습니다.");
                return;
            }

            bgmSource.transform.SetParent(mainCam.transform);
            bgmSource.transform.localPosition = Vector3.zero;
            sfxSource.transform.SetParent(mainCam.transform);
            sfxSource.transform.localPosition = Vector3.zero;
        }

        private AudioClip GetAudioClip(string key)
        {
            if (audioClips.TryGetValue(key, out AudioClip clip))
            {
                return clip;
            }
            else
            {
                AudioClip audioClip = Resources.Load<AudioClip>($"Sounds/{key}");
                if (audioClip == null)
                {
                    Debug.LogError($"SoundManager : {key} is not found.");
                    return null;
                }
                audioClips.Add(key, audioClip);
                return audioClip;
            }
        }

        public void UnloadScene()
        {
            bgmSource.transform.SetParent(transform);
            sfxSource.transform.SetParent(transform);
        }

        public void PlayBgm(SoundType sound, float volume = 0.7f)
        {
            AudioClip clip = GetAudioClip(sound.GetSoundKey());
            bgmSource.clip = clip;
            bgmSource.volume = volume;
            bgmSource.loop = true;
            bgmSource.Play();
        }

        public void StopBgm()
        {
            bgmSource.Stop();
            bgmSource.clip = null;
        }

        public void PlaySfx(SoundType sound, float volume = 0.8f)
        {
            AudioClip clip = GetAudioClip(sound.GetSoundKey());
            sfxSource.PlayOneShot(clip, volume);
        }
    }
    
    // TODO: Define으로 옮기기
    public enum SoundType
    {
        TitleBgm,
        LobbyBgm,
        MainBgm,
        CoinSfx,
        JumpSfx,
        SlideSfx,
        HitSfx,
        GameOverSfx,
        ButtonSfx,
    }
}
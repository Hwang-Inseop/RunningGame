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

        public IEnumerator PlaySfxWithDelay(SoundType sound, float volume = 0.8f)
        {
            AudioClip clip = GetAudioClip(sound.GetSoundKey());
            sfxSource.PlayOneShot(clip, volume);
            yield return new WaitForSeconds(clip.length); //사운드 종료되기 전 씬이 넘어가는 것을 방지
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
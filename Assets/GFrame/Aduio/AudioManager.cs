namespace GFrame
{
    using System.Collections.Generic;
    using UnityEngine;

    [MonoSingletonPath("Tools/AudioManager")]
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private AudioSource m_Music = null;
        private AudioSource m_Effect = null;
        private Dictionary<string, AudioClip> m_AudioClips = new Dictionary<string, AudioClip>();
        private AudioManager() { } 
        private void Awake()
        {
            var go = new GameObject();
            go.name = "music";
            m_Music = go.AddComponent<AudioSource>();
            m_Music.loop = true;
            m_Music.playOnAwake = false;
            go.transform.SetParent(transform);

            go = new GameObject();
            go.name = "effect";
            m_Effect = go.AddComponent<AudioSource>();
            m_Effect.playOnAwake = false;
            go.transform.SetParent(transform);
        }

        public void PlayMusic(string path)
        {
            m_Music.clip = LoadAudioClip(path);
            m_Music.Play();
        }

        public void PlayEffect(string path)
        {
            m_Effect.clip = LoadAudioClip(path);
            m_Effect.Play();
        }

        public void SetMusicVolume(float volume)
        {
            m_Music.volume = volume;
        }

        public void SetEffectVolume(float volume)
        {
            m_Effect.volume = volume;
        }

        private AudioClip LoadAudioClip(string path)
        {
            AudioClip ac;
            if (m_AudioClips.ContainsKey(path))
            {
                ac = m_AudioClips[path];
            }
            else
            {
                ac = ResManager.Instance.LoadSync(path) as AudioClip;
                m_AudioClips.Add(path, ac);
            }
            return ac;
        }
    }
}
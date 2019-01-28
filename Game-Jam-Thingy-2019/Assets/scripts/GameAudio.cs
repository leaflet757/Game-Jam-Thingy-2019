using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour 
{
    [System.Serializable]
    public class AudioItem
    {
        public string key;
        public AudioClip audioSource;
    }

    [SerializeField]
    private AudioItem[] soundFxSources;

    [SerializeField]
    private AudioItem[] bgTrackSources;

    [SerializeField]
    private AudioSource bgSource;

    private void Start()
    {
        Debug.Assert(bgSource != null, "Background audio source is null!");
        if (soundFxSources == null)
        {
            soundFxSources = new AudioItem[0];
        }
        if (bgTrackSources == null)
        {
            bgTrackSources = new AudioItem[0];
        }
    }

    private AudioItem FindAudioTrack(string key)
    {
        foreach (var audio in bgTrackSources)
        {
            if (audio.key == key)
            {
                return audio;
            }
        }
        return null;
    }

    private AudioItem FindSoundFx(string key)
    {
        foreach (var audio in soundFxSources)
        {
            if (audio.key == key)
            {
                return audio;
            }
        }
        return null;
    }

    public void PlayTrack(string key, bool restart = false)
    {
        AudioItem item = FindAudioTrack(key);
        if (item != null)
        {
            if (!bgSource.isPlaying || restart)
            {
                bgSource.Stop();
                bgSource.clip = item.audioSource;
                bgSource.loop = true;
                bgSource.volume = 0.5f;
                bgSource.Play();
                return;
            }
        }
        Debug.Log("Could not find audio for key: " + key);
    }

    public void StopTrack(string key)
    {
        AudioItem item = FindAudioTrack(key);
        if (item != null && bgSource.isPlaying)
        {
            bgSource.Stop();
            return;
        }
        Debug.Log("Could not find audio for key: " + key);
    }

    public void PlaySoundFx(string key, bool restart = false)
    {
        Debug.Log("TODO: need a way to play multiple sound effects");
        return;

        AudioItem item = FindSoundFx(key);
        if (item != null)
        {
            if (!bgSource.isPlaying || restart)
            {
                bgSource.Stop();
                bgSource.clip = item.audioSource;
                bgSource.loop = true;
                bgSource.volume = 0.5f;
                bgSource.Play();
                return;
            }
        }
        Debug.Log("Could not find sound fx for key: " + key);
    }

    public void StopSoundFx(string key)
    {
        Debug.Log("TODO: stop sound effect not implemented");
        return;

        AudioItem item = FindSoundFx(key);
        if (item != null && bgSource.isPlaying)
        {
            bgSource.Stop();
            return;
        }
        Debug.Log("Could not find sound fx for key: " + key);
    }

    public bool IsTrackPlaying(string key)
    {
        AudioItem item = FindAudioTrack(key);
        if (item != null)
        {
            return bgSource.clip == item.audioSource && bgSource.isPlaying;
        }
        return false;
    }

    public bool IsSoundFxPlaying(string key)
    {
        return false;
        AudioItem item = FindSoundFx(key);
        if (item != null)
        {
            
        }
    }
}

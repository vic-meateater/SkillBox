using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour, IDisposable
{
    [SerializeField] private Button _muteSoundButton;
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private AudioSource _backgroundAudioSource;
    [SerializeField] private AudioSource _uiAudioSource;
    [SerializeField] private AudioClip _backgroundAudioClip;
    [SerializeField] private AudioClip _buttonClickAudioClip;

    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("SoundManager");
                    _instance = singletonObject.AddComponent<SoundManager>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _muteSoundButton.onClick.AddListener(MuteAllSounds);

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _backgroundAudioSource.clip = _backgroundAudioClip;
        _backgroundAudioSource.Play();
    }

    private void MuteAllSounds()
    {
        PlayButtonClickSound();

        if (_backgroundAudioSource.isPlaying)
        {
            _backgroundAudioSource.Pause();
            _uiAudioSource.Pause();
        }
        else
        {
            _uiAudioSource.UnPause();
            _backgroundAudioSource.UnPause();
        }
    }

    public void PlayButtonClickSound() 
    {
        _uiAudioSource.clip = _buttonClickAudioClip;
        _uiAudioSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        
    }

    public void Dispose()
    {
        _muteSoundButton.onClick.RemoveListener(MuteAllSounds);
    }
}

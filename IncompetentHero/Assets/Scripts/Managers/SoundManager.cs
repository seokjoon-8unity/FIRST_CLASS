using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{    
    private static SoundManager _instance;
    public static SoundManager GetInstance()
    {
        if(_instance == null)
        {
        	GameObject go = GameObject.Find("SoundManager");
            //없으면 생성
            if(go == null)
            {
            	go = new GameObject { name = "SoundManager" };
            }
            if(go.GetComponent<SoundManager>() == null)
            {
            	go.AddComponent<SoundManager>();
            }

            DontDestroyOnLoad(go);
            
            //instance 할당
            _instance = go.GetComponent<SoundManager>();
        }
        
        return _instance;
    }

    [Header("BGM")]
    [SerializeField] private AudioClip[] _bgmClips;
    public float _bgmVolume;
    private AudioSource bgmPlayer;


    [Header("SFX")]
    public float _sfxVolume;
    [SerializeField] private int _sfxChannels;
    private int _sfxIndex;
    private AudioSource[] sfxPlayers;

    // 유일한 dontde라 여기에 저장
    public int Stage;
    
    void Awake() {
        if(_instance == null)
        {
        	GameObject go = GameObject.Find("SoundManager");
            //없으면 생성
            if(go == null)
            {
            	go = new GameObject { name = "SoundManager" };
            }
            if(go.GetComponent<SoundManager>() == null)
            {
            	go.AddComponent<SoundManager>();
            }

            DontDestroyOnLoad(go);
            
            //instance 할당
            _instance = go.GetComponent<SoundManager>();
        }
        
        Init();
    }

    void Init() {
        // 배경음 플레이어 세팅
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = _bgmVolume;

        // 효과음 플레이어 세팅
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[_sfxChannels];
        for (int i = 0; i < _sfxChannels; i++) {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = _sfxVolume;
        } 
    }

    // BGM 변경
    public void ChangeBGM(StageName stage) {
        if(bgmPlayer.isPlaying)
            bgmPlayer.Stop();
        
        bgmPlayer.clip = _bgmClips[(int)stage];
        bgmPlayer.Play();
    }

    public void StopBGM() {
        if(bgmPlayer.isPlaying)
            bgmPlayer.Stop();
    }

    // 빈 플레이어를 찾아서 클립 할당 후 재생
    public void PlaySFX(AudioClip sfxClip) {
        for(int i = 0; i < _sfxChannels; i++) {
            int loopIndex = (i + _sfxIndex) % _sfxChannels;

            if(sfxPlayers[loopIndex].isPlaying)
                continue;

            sfxPlayers[loopIndex].clip = sfxClip;
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
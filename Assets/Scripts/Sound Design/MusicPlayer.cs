using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> musicPlayList;

    private static MusicPlayer musicPlayerInstance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (musicPlayerInstance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            musicPlayerInstance = this;
        }
        else
            Destroy(gameObject); 
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
            StartPlay();
    }

    private void StartPlay()
    {
        int songIndex = Random.Range(0, musicPlayList.Count);
        audioSource.clip = musicPlayList[songIndex];
        audioSource.Play();
    }
}

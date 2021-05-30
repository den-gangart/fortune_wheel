using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MusicTests
{
    [UnityTest]
    public IEnumerator TestMusicPlayerIsSingletone()
    {
        GameObject listener = new GameObject();
        listener.AddComponent<AudioListener>();

        GameObject gameObject = new GameObject();
        var musicPlayer = gameObject.AddComponent<MusicPlayer>();
        gameObject.AddComponent<AudioSource>();

        AudioClip clip = AudioClip.Create("clip", 60, 1, 12000, false);
        musicPlayer.musicPlayList = new List<AudioClip>();
        musicPlayer.musicPlayList.Add(clip);

        yield return null;

        GameObject gameObject2 = new GameObject();
        var musicPlayer2 = gameObject2.AddComponent<MusicPlayer>();
        gameObject2.AddComponent<AudioSource>();
        musicPlayer2.musicPlayList = new List<AudioClip>();
        musicPlayer2.musicPlayList.Add(clip);

        yield return null;

        Assert.IsTrue(gameObject2 == null);
    }

    [UnityTest]
    public IEnumerator TestMusicAutoStart()
    {
        GameObject listener = new GameObject();
        listener.AddComponent<AudioListener>();

        GameObject gameObject = new GameObject();
        var musicPlayer = gameObject.AddComponent<MusicPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        AudioClip clip = AudioClip.Create("clip", 60, 1, 12000, false);
        musicPlayer.musicPlayList = new List<AudioClip>();
        musicPlayer.musicPlayList.Add(clip);

        yield return null;

        audioSource.Stop();

        yield return null;

        Assert.IsTrue(audioSource.isPlaying);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        MusicPlayer music = FindObjectOfType<MusicPlayer>();
        if (music != this)
        {
            Destroy(music);
        }
        DontDestroyOnLoad(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // ...
    [SerializeField] private AudioClip m_levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(m_levelMusic); // run the level music
    }

}

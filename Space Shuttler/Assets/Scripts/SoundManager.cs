using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioSource _MusicSource, _SeSource;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        _MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

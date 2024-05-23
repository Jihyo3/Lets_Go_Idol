using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] bgMusic;
    public Toggle backGroundMusic1;
    public Toggle backGroundMusic2;
    public Toggle backGroundMusic3;
    //private Toggle currentToggle;
    private AudioSource audioSource;
    public AudioMixer mixer;
    public Slider volume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic(0);

        backGroundMusic1.onValueChanged.AddListener(delegate { ToggleClick(); });
        backGroundMusic2.onValueChanged.AddListener(delegate { ToggleClick(); });
        backGroundMusic3.onValueChanged.AddListener(delegate { ToggleClick(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBackgroundMusic(int index)
    {
        if (index >= 0 && index < bgMusic.Length)
        {
            audioSource.clip = bgMusic[index];
            audioSource.Play();
        }
    }
    public void ToggleClick()
    {
        if (backGroundMusic1.isOn)
        {
            PlayBackgroundMusic(0);
        }
        else if (backGroundMusic2.isOn)
        {
            PlayBackgroundMusic(1);
        }
        else if (backGroundMusic3.isOn)
        {
            PlayBackgroundMusic(2);
        }
    }

    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat("BackMg", Mathf.Log10(sliderVal) * 20);
    }

}

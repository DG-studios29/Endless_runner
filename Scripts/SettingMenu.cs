using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void SetVolume(float volume)
	{
        audioMixer.SetFloat("volume", volume);
	}

    public void setQuality(int qualityIndex)
	{
        QualitySettings.SetQualityLevel(qualityIndex);
	}

    public void setFullScreen(bool isfullscreen)
	{
        Screen.fullScreen = isfullscreen;

    }
}

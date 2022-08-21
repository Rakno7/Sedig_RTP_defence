using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsUI : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider MainVolumeSlider;
    public Slider AmbianceVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    void Start()
    {
        OnAmbianceVolumeChange();
        OnMainVolumeChange();
        OnSFXVolumeChange();
        OnAmbianceVolumeChange();
    }

    public void OnMainVolumeChange()
    {
       float newVolume = MainVolumeSlider.value;
       if(newVolume <= 0)
       {
        newVolume = -80;
       }
       else
       {
        //returns 10 to the power of (what), gives you the value of newVolume;
        // if newVolume was 30 the log 10 would be around 1.48
        // this is important as the mixers range between -80 and 20db and the adjustments are logaristic meaning each adjustment is explonetial.
        //Atleast I think... so a volume of 1 would give us 10db in the mixer.
        newVolume = Mathf.Log10(newVolume);
        //since the max value of the slider is 1, multiplying the slider value by 20 will give us a max range of 20.
        newVolume = newVolume * 20;
       }
       //once the conversion is complete set the mixer volume.
       mixer.SetFloat("MasterVolume", newVolume);
    }
    public void OnAmbianceVolumeChange()
    {
       float newVolume = AmbianceVolumeSlider.value;
       if(newVolume <= 0)
       {
        newVolume = -80;
       }
       else 
       {
        newVolume = Mathf.Log10(newVolume) * 20;
       }
       mixer.SetFloat("AmbianceVolume", newVolume);
    }
    public void OnMusicVolumeChange()
    {
       float newVolume = MusicVolumeSlider.value;
       if(newVolume <= 0)
       {
        newVolume = -80;
       }
        else 
       {
        newVolume = Mathf.Log10(newVolume);
        newVolume = newVolume * 20;
       }
       mixer.SetFloat("MusicVolume", newVolume);
    }
    public void OnSFXVolumeChange()
    {
       float newVolume = SFXVolumeSlider.value;
       if(newVolume <= 0)
       {
        newVolume = -80;
       }
        else 
       {
        newVolume = Mathf.Log10(newVolume) * 20;
       }
       mixer.SetFloat("SFXVolume", newVolume);
       
    }


}

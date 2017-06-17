using UnityEngine;
using System.Collections;
        // Takes care of sounds
public class SoundManager: MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource SFXSource;
    public AudioSource musicSource;

    private float m_highPitchRange = 1.05f;
    private float m_lowPitchRange = 0.95f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    /***************************************************************************************************/

        // Plays the sound
    public void PlaySound(AudioClip clip)
    {
        SFXSource.pitch = RandomizePitch() * SFXSource.volume;

        SFXSource.clip = clip;
        SFXSource.Play();
    }

        // Sets AudioSources' volume
    public void SetSoundVolume(float volume)
    {
        SFXSource.volume = musicSource.volume = volume;
    }

    /***************************************************************************************************/

        // Randomizes audio source pitch
    private float RandomizePitch()
    {
        return Random.Range(m_lowPitchRange, m_highPitchRange);
    }
}

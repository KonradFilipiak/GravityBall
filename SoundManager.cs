using UnityEngine;
using System.Collections;
        //takes care of sounds
public class SoundManager: MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource m_SFXSource;
    public AudioSource m_musicSource;

    private float m_highPitchRange = 1.05f;
    private float m_lowPitchRange = 0.95f;

            //makes sure SoundManager is a singleton
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
            //plays the sound
    public void PlaySound(AudioClip clip)
    {
        m_SFXSource.pitch = RandomizePitch() * m_SFXSource.volume;

        m_SFXSource.clip = clip;
        m_SFXSource.Play();
    }
            //sets AudioSources' volume
    public void SetSoundVolume(float volume)
    {
        m_SFXSource.volume = m_musicSource.volume = volume;
    }
            //randomize audio source pitch
    private float RandomizePitch()
    {
        return Random.Range(m_lowPitchRange, m_highPitchRange);
    }
}

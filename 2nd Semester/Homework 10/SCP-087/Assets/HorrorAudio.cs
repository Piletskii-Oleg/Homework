using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorAudio : MonoBehaviour
{
    [Header("Horror")]
    public AudioSource horrorAudio;
    public AudioClip[] horrorSFX;
    private float minWaitBetweenPlays = 2f;
    private float maxWaitBetweenPlays = 15f;
    private float waitTimeCooldown = -1f;

    private void Reset()
    {
        horrorAudio = GetOrCreateAudioSource("Horror Audio");
    }

    private void Update()
    {
        if (!horrorAudio.isPlaying)
        {
            if (waitTimeCooldown < 0f)
            {
                PlayHorrorAudio();
                waitTimeCooldown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCooldown -= Time.deltaTime;
            }
        }
    }

    private void PlayHorrorAudio() => PlayRandomClip(horrorAudio, horrorSFX);

    private AudioSource GetOrCreateAudioSource(string name)
    {
        // Try to get the audiosource.
        AudioSource result = System.Array.Find(GetComponentsInChildren<AudioSource>(), a => a.name == name);
        if (result)
            return result;

        // Audiosource does not exist, create it.
        result = new GameObject(name).AddComponent<AudioSource>();
        result.spatialBlend = 1;
        result.playOnAwake = false;
        result.transform.SetParent(transform, false);
        return result;
    }

    private static void PlayRandomClip(AudioSource audio, AudioClip[] clips)
    {
        if (!audio || clips.Length <= 0)
            return;

        // Get a random clip. If possible, make sure that it's not the same as the clip that is already on the audiosource.
        AudioClip clip = clips[Random.Range(0, clips.Length - 1)];
        if (clips.Length > 1)
            while (clip == audio.clip)
                clip = clips[Random.Range(0, clips.Length - 1)];

        // Play the clip.
        audio.clip = clip;
        audio.Play();
    }
}

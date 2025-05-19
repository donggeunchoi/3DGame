using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioSource audioSource;

    public float fadeTime;

    public float maxVolume;

    private float targetVolume;
    
    private void Start()
    {
        targetVolume = 0.0f;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = targetVolume;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"[MUSIC] 현재 볼륨: {audioSource.volume} / 목표 볼륨: {targetVolume} / 재생 중인가? {audioSource.isPlaying}");
        if (!Mathf.Approximately(audioSource.volume, targetVolume))
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, (maxVolume / fadeTime) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[MUSIC] 트리거 충돌 감지: {other.name}, 태그: {other.tag}");
        if (other.CompareTag("Player"))
        {
            targetVolume = maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = 0.0f;
        }
    }
}

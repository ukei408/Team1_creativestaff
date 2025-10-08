using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioClip bgmClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f; // 音量調整（0.0?1.0）

        audioSource.Play();
    }
}
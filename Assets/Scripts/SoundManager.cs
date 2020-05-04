using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    AudioSource audioSource;
    public AudioClip loss;
    public AudioClip win;
    public AudioClip paddleHit;
    public AudioClip goal;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneSHot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    void Update()
    {
        
    }
}

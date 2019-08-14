using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager Instance;

    private AudioSource AudioSource;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
        AudioSource = gameObject.AddComponent<AudioSource>();
    }

    public static AudioManager GetInstance()
    {
        if (Instance == null)
        {
            var obj = new GameObject(nameof(AudioManager));
            obj.AddComponent<AudioManager>();
            Instantiate(obj);
        }

        return Instance;
    }

    public void PlayOneShot(AudioClip clip, float volume = 1f)
    {
        AudioSource.PlayOneShot(clip, volume);
    }

    public void PlayBGM(AudioClip clip, float volume = 1f)
    {
        AudioSource.Stop();
        
        AudioSource.clip = clip;
        AudioSource.loop = true;
        AudioSource.volume = volume;
        AudioSource.Play();
    }
}

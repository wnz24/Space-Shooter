using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource ice;
    public AudioSource hit;
    public AudioSource fire;
    public AudioSource pause;
    public AudioSource unpause;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlaySound (AudioSource sound)
    {
        sound.Stop();
        sound.Play();
    }
}

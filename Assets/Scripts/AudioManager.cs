using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource ice;
    public AudioSource hit;
    public AudioSource fire;
    public AudioSource pause;
    public AudioSource unpause;
    public AudioSource boom2;
    public AudioSource hitRock;
    public AudioSource shoot;
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
    public void PlayModifiedSound (AudioSource sound)
    {
        sound.pitch = Random.Range(0.7f, 1.3f);
        sound.Stop();
        sound.Play();
    }
}

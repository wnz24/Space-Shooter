using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;

    public float worldSpeed;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel") || Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if(UIController.Instance.pausepanel.activeSelf)
        {
            Time.timeScale = 1f;
            UIController.Instance.pausepanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            UIController.Instance.pausepanel.SetActive(true);
            PlayerController.Instance.OnBoostExit();
        }
    }
}

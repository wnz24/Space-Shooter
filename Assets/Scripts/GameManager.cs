using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
            AudioManager.Instance.PlaySound(AudioManager.Instance.unpause);

            Time.timeScale = 1f;
            UIController.Instance.pausepanel.SetActive(false);
        }
        else
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.pause);

            Time.timeScale = 0f;
            UIController.Instance.pausepanel.SetActive(true);
            PlayerController.Instance.OnBoostExit();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
      
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    public void GameOver()
    {
        StartCoroutine(LoadGameOverScene());
        
    }
    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }

}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;    
   [SerializeField]  private Slider energyslider;
    [SerializeField] private  TMP_Text energytext;

   [SerializeField]  private Slider Healthslider;
    [SerializeField] private  TMP_Text healthtext;

    public GameObject pausepanel;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetMaxEnergy(float energy, float max)
    {
        // Null checks to prevent MissingReferenceException
        if (energyslider == null || energytext == null)
            return;

        energyslider.maxValue = max;
        energyslider.value = Mathf.Round(energy);
        energytext.text = Mathf.Round(energy) + " / " + max;
    }

    public void SetMaxHealth(float energy, float max)
    {
        //Null checks for safety
        if (Healthslider == null || healthtext == null)
            return;

        Healthslider.maxValue = max;
        Healthslider.value = Mathf.Round(energy);
        healthtext.text = Mathf.Round(energy) + " / " + max;
    }
}

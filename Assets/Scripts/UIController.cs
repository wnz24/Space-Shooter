using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;    
   [SerializeField]  private Slider slider;
    [SerializeField] private  TMP_Text text;

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
        slider.maxValue = max;
        slider.value = Mathf.Round(energy);
        text.text = Mathf.Round(energy) + " / " + max;

    }
}

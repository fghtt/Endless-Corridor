using UnityEngine;
using TMPro;

public class RebirthTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText; 
    public float respawnTime = 3f; 

    private float timeRemaining;

    void Start()
    {
        timeRemaining = respawnTime;
        UpdateTimerText(); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
        timeRemaining = respawnTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; 
            UpdateTimerText(); 
        }
        else
        {
            timeRemaining = 0;
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = $"Вы возродитесь через {Mathf.CeilToInt(timeRemaining)}";
    }
}
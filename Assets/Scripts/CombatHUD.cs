using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatHUD : MonoBehaviour
{
    [Header("Индикаторы здоровья")]
    [SerializeField] private Slider localHealthSlider;
    [SerializeField] private TextMeshProUGUI localHealthText;

    [Header("Счетчик побед")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Экран гибели")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private TextMeshProUGUI respawnTimerText;

    public void UpdateHealth(int currentHp, int maxHp = 100)
    {
        if (localHealthSlider != null)
        {
            localHealthSlider.maxValue = maxHp;
            localHealthSlider.value = currentHp;
        }

        if (localHealthText != null)
            localHealthText.text = $"{Mathf.Max(0, currentHp)} / {maxHp}";
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Побед: {score}";
    }

    public void ShowDeathScreen(bool isDead, float respawnTime = 0f)
    {
        if (deathPanel != null) deathPanel.SetActive(isDead);

        if (isDead && respawnTimerText != null)
            respawnTimerText.text = $"Возрождение через: {respawnTime:F0} сек...";
    }

    public void UpdateRespawnTimer(float remainingTime)
    {
        if (respawnTimerText != null && deathPanel != null && deathPanel.activeSelf)
            respawnTimerText.text =
                $"Возрождение через: {Mathf.CeilToInt(remainingTime)} сек...";
    }
}

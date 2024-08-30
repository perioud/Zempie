using UnityEngine;
using TMPro;  // Ensure you have TextMesh Pro package
using System.Collections;

public class TimerWithFade : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;  // 타이머를 표시할 TextMesh Pro UI 텍스트
    [SerializeField] private float timerDuration = 10.0f;  // 타이머 지속 시간
    [SerializeField] private FadeManager fadeManager;  // FadeManager 스크립트

    private float currentTime;

    private void Start()
    {
        if (fadeManager == null)
        {
            Debug.LogError("FadeManager is not assigned.");
            return;
        }

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        currentTime = timerDuration;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            if (timerText != null)
            {
                timerText.text = $"{minutes:00}:{seconds:00}";
            }
            yield return null;
        }

        // 타이머가 끝나면 "시간 종료"를 출력하고 FadeIn을 호출
        if (timerText != null)
        {
            timerText.text = "00:00";
        }
        Debug.Log("시간 종료");

        // 타이머 종료 후 FadeIn 호출
        if (fadeManager != null)
        {
            fadeManager.StartFadeIn();  // 타이머 종료 후 페이드 인을 호출
        }
    }
}

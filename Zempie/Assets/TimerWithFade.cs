using UnityEngine;
using TMPro;  // Ensure you have TextMesh Pro package
using System.Collections;

public class TimerWithFade : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;  // Ÿ�̸Ӹ� ǥ���� TextMesh Pro UI �ؽ�Ʈ
    [SerializeField] private float timerDuration = 10.0f;  // Ÿ�̸� ���� �ð�
    [SerializeField] private FadeManager fadeManager;  // FadeManager ��ũ��Ʈ

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

        // Ÿ�̸Ӱ� ������ "�ð� ����"�� ����ϰ� FadeIn�� ȣ��
        if (timerText != null)
        {
            timerText.text = "00:00";
        }
        Debug.Log("�ð� ����");

        // Ÿ�̸� ���� �� FadeIn ȣ��
        if (fadeManager != null)
        {
            fadeManager.StartFadeIn();  // Ÿ�̸� ���� �� ���̵� ���� ȣ��
        }
    }
}

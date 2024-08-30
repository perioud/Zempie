//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class FadeManager : MonoBehaviour
//{
//    public CanvasGroup imageCanvasGroup; // Image�� �߰��� CanvasGroup
//    public Button fadeButton;            // ��ư ������Ʈ
//    public GameObject uiToDeactivate;    // ���̵� �� �� ��Ȱ��ȭ�� UI ���
//    public GameObject uiToActivate;      // ���̵� �� �� Ȱ��ȭ�� UI ���
//    public float fadeDuration = 1.0f;    // ���̵� ��/�ƿ� �ð�

//    private void Start()
//    {
//        if (fadeButton != null)
//        {
//            fadeButton.onClick.AddListener(StartFadeEffect);
//        }
//        else
//        {
//            Debug.LogError("Fade Button is not assigned.");
//        }
//    }

//    public void StartFadeEffect()
//    {
//        StartCoroutine(FadeInAndOut());
//    }

//    private IEnumerator FadeInAndOut()
//    {
//        // ���̵� ��
//        imageCanvasGroup.alpha = 0f;
//        imageCanvasGroup.gameObject.SetActive(true); // UI ��Ҹ� Ȱ��ȭ
//        yield return StartCoroutine(Fade(imageCanvasGroup, 0f, 1f));

//        // ���̵� �� �� UI ��� ����
//        if (uiToDeactivate != null)
//        {
//            uiToDeactivate.SetActive(false);
//        }

//        if (uiToActivate != null)
//        {
//            uiToActivate.SetActive(true);
//        }

//        // 2�� ���
//        yield return new WaitForSeconds(2f);

//        // ���̵� �ƿ�
//        yield return StartCoroutine(Fade(imageCanvasGroup, 1f, 0f));

//        imageCanvasGroup.gameObject.SetActive(false); // UI ��Ҹ� ��Ȱ��ȭ
//    }

//    private IEnumerator Fade(CanvasGroup group, float startAlpha, float endAlpha)
//    {
//        float elapsedTime = 0f;
//        while (elapsedTime < fadeDuration)
//        {
//            elapsedTime += Time.deltaTime;
//            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
//            group.alpha = alpha;
//            yield return null;
//        }
//        group.alpha = endAlpha; // Ensure final alpha value
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Ensure you have TextMesh Pro package
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup imageCanvasGroup; // Image�� �߰��� CanvasGroup
    public Button fadeButton;            // ��ư ������Ʈ
    public GameObject uiToDeactivate;    // ���̵� �� �� ��Ȱ��ȭ�� UI ���
    public GameObject uiToActivate;      // ���̵� �� �� Ȱ��ȭ�� UI ���
    public float fadeDuration = 1.0f;    // ���̵� ��/�ƿ� �ð�

    private void Start()
    {
        if (fadeButton != null)
        {
            fadeButton.onClick.AddListener(StartFadeEffect);
        }
        else
        {
            Debug.LogError("Fade Button is not assigned.");
        }
    }

    public void StartFadeEffect()
    {
        StartCoroutine(FadeInAndOut());
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeInAndOut()
    {
        // ���̵� ��
        imageCanvasGroup.alpha = 0f;
        imageCanvasGroup.gameObject.SetActive(true); // UI ��Ҹ� Ȱ��ȭ
        yield return StartCoroutine(Fade(imageCanvasGroup, 0f, 1f));

        // ���̵� �� �� UI ��� ����
        if (uiToDeactivate != null)
        {
            uiToDeactivate.SetActive(false);
        }

        if (uiToActivate != null)
        {
            uiToActivate.SetActive(true);
        }

        // 2�� ���
        yield return new WaitForSeconds(2f);

        // ���̵� �ƿ�
        yield return StartCoroutine(Fade(imageCanvasGroup, 1f, 0f));

        imageCanvasGroup.gameObject.SetActive(false); // UI ��Ҹ� ��Ȱ��ȭ
    }

    private IEnumerator FadeIn()
    {
        imageCanvasGroup.alpha = 0f;
        imageCanvasGroup.gameObject.SetActive(true); // UI ��Ҹ� Ȱ��ȭ
        yield return StartCoroutine(Fade(imageCanvasGroup, 0f, 1f));
    }

    private IEnumerator Fade(CanvasGroup group, float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            group.alpha = alpha;
            yield return null;
        }
        group.alpha = endAlpha; // Ensure final alpha value
    }
}

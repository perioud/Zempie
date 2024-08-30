//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class FadeManager : MonoBehaviour
//{
//    public CanvasGroup imageCanvasGroup; // Image에 추가한 CanvasGroup
//    public Button fadeButton;            // 버튼 컴포넌트
//    public GameObject uiToDeactivate;    // 페이드 인 후 비활성화할 UI 요소
//    public GameObject uiToActivate;      // 페이드 인 후 활성화할 UI 요소
//    public float fadeDuration = 1.0f;    // 페이드 인/아웃 시간

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
//        // 페이드 인
//        imageCanvasGroup.alpha = 0f;
//        imageCanvasGroup.gameObject.SetActive(true); // UI 요소를 활성화
//        yield return StartCoroutine(Fade(imageCanvasGroup, 0f, 1f));

//        // 페이드 인 후 UI 요소 조작
//        if (uiToDeactivate != null)
//        {
//            uiToDeactivate.SetActive(false);
//        }

//        if (uiToActivate != null)
//        {
//            uiToActivate.SetActive(true);
//        }

//        // 2초 대기
//        yield return new WaitForSeconds(2f);

//        // 페이드 아웃
//        yield return StartCoroutine(Fade(imageCanvasGroup, 1f, 0f));

//        imageCanvasGroup.gameObject.SetActive(false); // UI 요소를 비활성화
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
    public CanvasGroup imageCanvasGroup; // Image에 추가한 CanvasGroup
    public Button fadeButton;            // 버튼 컴포넌트
    public GameObject uiToDeactivate;    // 페이드 인 후 비활성화할 UI 요소
    public GameObject uiToActivate;      // 페이드 인 후 활성화할 UI 요소
    public float fadeDuration = 1.0f;    // 페이드 인/아웃 시간

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
        // 페이드 인
        imageCanvasGroup.alpha = 0f;
        imageCanvasGroup.gameObject.SetActive(true); // UI 요소를 활성화
        yield return StartCoroutine(Fade(imageCanvasGroup, 0f, 1f));

        // 페이드 인 후 UI 요소 조작
        if (uiToDeactivate != null)
        {
            uiToDeactivate.SetActive(false);
        }

        if (uiToActivate != null)
        {
            uiToActivate.SetActive(true);
        }

        // 2초 대기
        yield return new WaitForSeconds(2f);

        // 페이드 아웃
        yield return StartCoroutine(Fade(imageCanvasGroup, 1f, 0f));

        imageCanvasGroup.gameObject.SetActive(false); // UI 요소를 비활성화
    }

    private IEnumerator FadeIn()
    {
        imageCanvasGroup.alpha = 0f;
        imageCanvasGroup.gameObject.SetActive(true); // UI 요소를 활성화
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

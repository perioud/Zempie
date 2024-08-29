using UnityEngine;
using System.Collections;

public class TriggerTrash : MonoBehaviour
{
    public GameObject uiElement;  // UI 요소를 참조할 변수
    public float disableDuration = 2f; // 이동 제한 지속 시간

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어가 쓰레기와 충돌할 때
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // UI를 표시
                ShowUI();
            }
        }
    }

    private void ShowUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(true);
            StartCoroutine(HideUIAfterDelay(2f));  // 2초 후에 UI를 숨김
        }
    }

    private IEnumerator HideUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }
    }
}

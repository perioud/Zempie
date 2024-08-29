using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject uiElement;  // UI 요소를 참조할 변수
    private bool uiVisible = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        if (!uiVisible)
        {
            uiElement.SetActive(true);
            uiVisible = true;
            StartCoroutine(HideUIAfterDelay(2f));  // 2초 후에 UI를 숨김
        }
    }

    private IEnumerator HideUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        uiElement.SetActive(false);
        uiVisible = false;
    }
}

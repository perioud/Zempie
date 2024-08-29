using UnityEngine;
using System.Collections;

public class TriggerTrash : MonoBehaviour
{
    public GameObject uiElement;  // UI ��Ҹ� ������ ����
    public float disableDuration = 2f; // �̵� ���� ���� �ð�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾ ������� �浹�� ��
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // UI�� ǥ��
                ShowUI();
            }
        }
    }

    private void ShowUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(true);
            StartCoroutine(HideUIAfterDelay(2f));  // 2�� �Ŀ� UI�� ����
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

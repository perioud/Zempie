using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectA : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾���� �浹�� �˻�
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interacted with Object A, loading ending scene.");
            SceneManager.LoadScene(6); // ���� ������ ��ȯ
        }
    }
}

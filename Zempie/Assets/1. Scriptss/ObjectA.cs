using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectA : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와의 충돌을 검사
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interacted with Object A, loading ending scene.");
            SceneManager.LoadScene(6); // 엔딩 씬으로 전환
        }
    }
}

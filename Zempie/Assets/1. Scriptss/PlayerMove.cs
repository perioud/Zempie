using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{//wasd로 상하좌우 이동
    public float moveSpeed = 5f; // 이동 속도

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // 좌우 이동 입력
        float moveY = Input.GetAxis("Vertical"); // 상하 이동 입력

        Vector2 movement = new Vector2(moveX, moveY); // 이동 벡터 생성
        rb.velocity = movement * moveSpeed; // Rigidbody2D의 속도 설정

        if (Input.GetKeyDown(KeyCode.E))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex == 0)
            {
                SceneManager.LoadScene(1); // 0번 씬에서 1번 씬으로 전환
            }
            else if (currentSceneIndex == 1)
            {
                SceneManager.LoadScene(0); // 1번 씬에서 0번 씬으로 전환
            }
        }
    }

    
}

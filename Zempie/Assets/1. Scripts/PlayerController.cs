using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // 플레이어 이동 속도
    private Rigidbody2D rb;
    private Animator animator;    // Animator 컴포넌트 참조

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  // Animator 컴포넌트 초기화
    }

    void Update()
    {
        // 플레이어 이동 입력 받기
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        // 수평 또는 수직 입력만 처리하도록 수정
        if (Mathf.Abs(moveInputX) > Mathf.Abs(moveInputY))
        {
            // 수평 이동만 활성화
            rb.velocity = new Vector2(moveInputX * moveSpeed, 0);

            // 애니메이션 상태 설정
            animator.SetFloat("Speed", Mathf.Abs(moveInputX));
            animator.SetBool("IsMovingLeft", moveInputX < 0);
            animator.SetBool("IsMovingRight", moveInputX > 0);  // 오른쪽 이동 상태 설정
        }
        else if (Mathf.Abs(moveInputY) > 0)
        {
            // 수직 이동만 활성화 (상하 이동을 고려할 경우 추가 필요)
            rb.velocity = new Vector2(0, moveInputY * moveSpeed);

            // 수직 이동 애니메이션 제어 (예: Idle 상태로 전환)
            animator.SetFloat("Speed", Mathf.Abs(moveInputY));
            animator.SetBool("IsMovingLeft", false);  // 수직 이동 시 왼쪽 이동 상태 해제
            animator.SetBool("IsMovingRight", false); // 수직 이동 시 오른쪽 이동 상태 해제
        }
        else
        {
            // 이동이 없을 경우 Idle 상태
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex == 3)
            {
                //SceneManager.LoadScene(1); // 0번 씬에서 1번 씬으로 전환
                SceneManager.LoadScene(4);
            }
            else if (currentSceneIndex == 4)
            {
                //SceneManager.LoadScene(0); // 1번 씬에서 0번 씬으로 전환
                SceneManager.LoadScene(3);
            }
        }
    }
}

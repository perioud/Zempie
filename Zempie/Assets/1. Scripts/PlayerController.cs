using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �÷��̾� �̵� �ӵ�
    private Rigidbody2D rb;
    private Animator animator;    // Animator ������Ʈ ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  // Animator ������Ʈ �ʱ�ȭ
    }

    void Update()
    {
        // �÷��̾� �̵� �Է� �ޱ�
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        // ���� �Ǵ� ���� �Է¸� ó���ϵ��� ����
        if (Mathf.Abs(moveInputX) > Mathf.Abs(moveInputY))
        {
            // ���� �̵��� Ȱ��ȭ
            rb.velocity = new Vector2(moveInputX * moveSpeed, 0);

            // �ִϸ��̼� ���� ����
            animator.SetFloat("Speed", Mathf.Abs(moveInputX));
            animator.SetBool("IsMovingLeft", moveInputX < 0);
            animator.SetBool("IsMovingRight", moveInputX > 0);  // ������ �̵� ���� ����
        }
        else if (Mathf.Abs(moveInputY) > 0)
        {
            // ���� �̵��� Ȱ��ȭ (���� �̵��� ����� ��� �߰� �ʿ�)
            rb.velocity = new Vector2(0, moveInputY * moveSpeed);

            // ���� �̵� �ִϸ��̼� ���� (��: Idle ���·� ��ȯ)
            animator.SetFloat("Speed", Mathf.Abs(moveInputY));
            animator.SetBool("IsMovingLeft", false);  // ���� �̵� �� ���� �̵� ���� ����
            animator.SetBool("IsMovingRight", false); // ���� �̵� �� ������ �̵� ���� ����
        }
        else
        {
            // �̵��� ���� ��� Idle ����
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
                //SceneManager.LoadScene(1); // 0�� ������ 1�� ������ ��ȯ
                SceneManager.LoadScene(4);
            }
            else if (currentSceneIndex == 4)
            {
                //SceneManager.LoadScene(0); // 1�� ������ 0�� ������ ��ȯ
                SceneManager.LoadScene(3);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{//wasd�� �����¿� �̵�
    public float moveSpeed = 5f; // �̵� �ӵ�

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // �¿� �̵� �Է�
        float moveY = Input.GetAxis("Vertical"); // ���� �̵� �Է�

        Vector2 movement = new Vector2(moveX, moveY); // �̵� ���� ����
        rb.velocity = movement * moveSpeed; // Rigidbody2D�� �ӵ� ����

        if (Input.GetKeyDown(KeyCode.E))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex == 0)
            {
                SceneManager.LoadScene(1); // 0�� ������ 1�� ������ ��ȯ
            }
            else if (currentSceneIndex == 1)
            {
                SceneManager.LoadScene(0); // 1�� ������ 0�� ������ ��ȯ
            }
        }
    }

    
}

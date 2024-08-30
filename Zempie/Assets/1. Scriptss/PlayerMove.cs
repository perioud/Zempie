using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{//wasd�� �����¿� �̵�
    public float moveSpeed = 5f; // �̵� �ӵ�

    private Rigidbody2D rb;
    public int moveCount = 0;

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
            
            if (moveCount < 6)
            {
                moveCount = moveCount + 1;
                if (currentSceneIndex == 0)
                {
                    //SceneManager.LoadScene(1); // 0�� ������ 1�� ������ ��ȯ
                    SceneManager.LoadScene(4);
                }
                else if (currentSceneIndex == 1)
                {
                    //SceneManager.LoadScene(0); // 1�� ������ 0�� ������ ��ȯ
                    SceneManager.LoadScene(3);
                }
            }
            else if (moveCount > 5)
            {
                return;
            }
        }
    }

    
}

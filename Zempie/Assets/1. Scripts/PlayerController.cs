//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f;  // �÷��̾� �̵� �ӵ�

//    private Rigidbody2D rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // �÷��̾� �̵� �Է� �ޱ�
//        float moveInputX = Input.GetAxis("Horizontal");
//        float moveInputY = Input.GetAxis("Vertical");

//        // ���� �Ǵ� ���� �Է¸� ó���ϵ��� ����
//        if (Mathf.Abs(moveInputX) > Mathf.Abs(moveInputY))
//        {
//            // ���� �̵��� Ȱ��ȭ
//            rb.velocity = new Vector2(moveInputX * moveSpeed, 0);
//        }
//        else
//        {
//            // ���� �̵��� Ȱ��ȭ
//            rb.velocity = new Vector2(0, moveInputY * moveSpeed);
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �÷��̾� �̵� �ӵ�

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        }
        else
        {
            // ���� �̵��� Ȱ��ȭ
            rb.velocity = new Vector2(0, moveInputY * moveSpeed);
        }

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

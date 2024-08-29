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
    }
}

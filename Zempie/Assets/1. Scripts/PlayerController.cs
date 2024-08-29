//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f;  // 플레이어 이동 속도

//    private Rigidbody2D rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // 플레이어 이동 입력 받기
//        float moveInputX = Input.GetAxis("Horizontal");
//        float moveInputY = Input.GetAxis("Vertical");

//        // 수평 또는 수직 입력만 처리하도록 수정
//        if (Mathf.Abs(moveInputX) > Mathf.Abs(moveInputY))
//        {
//            // 수평 이동만 활성화
//            rb.velocity = new Vector2(moveInputX * moveSpeed, 0);
//        }
//        else
//        {
//            // 수직 이동만 활성화
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
    public float moveSpeed = 5f;  // 플레이어 이동 속도

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        }
        else
        {
            // 수직 이동만 활성화
            rb.velocity = new Vector2(0, moveInputY * moveSpeed);
        }

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

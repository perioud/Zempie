using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스

public class TextManager : MonoBehaviour
{
    public GameObject text_1; // UI 텍스트 배열
    public GameObject text_2; // UI 텍스트 배열
    private int textCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        // 스페이스바가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            text_1.SetActive(false);
            text_2.SetActive(true);
            textCount ++;
            Debug.Log(textCount);
                if(textCount == 2)
                {
                // 마지막 텍스트 이후에는 지정된 씬으로 전환
                SceneManager.LoadScene(2);
                }
        }
    }
}
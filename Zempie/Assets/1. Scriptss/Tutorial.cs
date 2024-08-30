using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� ���ӽ����̽�

public class TextManager : MonoBehaviour
{
    public GameObject text_1; // UI �ؽ�Ʈ �迭
    public GameObject text_2; // UI �ؽ�Ʈ �迭
    private int textCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        // �����̽��ٰ� ������ ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            text_1.SetActive(false);
            text_2.SetActive(true);
            textCount ++;
            Debug.Log(textCount);
                if(textCount == 2)
                {
                // ������ �ؽ�Ʈ ���Ŀ��� ������ ������ ��ȯ
                SceneManager.LoadScene(2);
                }
        }
    }
}
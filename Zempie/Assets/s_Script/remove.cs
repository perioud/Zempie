using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    private void Awake()
    {
       
         // ���� �ε�� �� ������Ʈ�� ������ �������� Ȯ��
        if (PlayerPrefs.GetInt(gameObject.name + "_Destroyed", 0) == 1)
        {
            Destroy(gameObject); // ������Ʈ�� ������ ���¶��, �ٽ� �������� �ʰ� �ı�
        }
    }

    void Start()
    {
        // Start���� �ʱ�ȭ�� ��������, ������Ʈ�� ó�� �����Ǿ��� ���� ����ǰ� ��
        if (!PlayerPrefs.HasKey(gameObject.name + "_Initialized"))
        {
            PlayerPrefs.SetInt(gameObject.name + "_Initialized", 1);
            PlayerPrefs.SetInt(gameObject.name + "_Destroyed", 0); // ó������ �������� �ʵ��� 0���� ����
        }
    }
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ������Ʈ�� �÷��̾�� �浹���� ��, ���� ���¸� �����ϰ� ������Ʈ�� �ı�
            PlayerPrefs.SetInt(gameObject.name + "_Destroyed", 1);
            Destroy(gameObject);
        }
    }
}

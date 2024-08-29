using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    private void Awake()
    {
       
         // 씬이 로드될 때 오브젝트가 삭제된 상태인지 확인
        if (PlayerPrefs.GetInt(gameObject.name + "_Destroyed", 0) == 1)
        {
            Destroy(gameObject); // 오브젝트가 삭제된 상태라면, 다시 생성되지 않게 파괴
        }
    }

    void Start()
    {
        // Start에서 초기화를 해주지만, 오브젝트가 처음 생성되었을 때만 실행되게 함
        if (!PlayerPrefs.HasKey(gameObject.name + "_Initialized"))
        {
            PlayerPrefs.SetInt(gameObject.name + "_Initialized", 1);
            PlayerPrefs.SetInt(gameObject.name + "_Destroyed", 0); // 처음에는 삭제되지 않도록 0으로 설정
        }
    }
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 오브젝트가 플레이어와 충돌했을 때, 삭제 상태를 저장하고 오브젝트를 파괴
            PlayerPrefs.SetInt(gameObject.name + "_Destroyed", 1);
            Destroy(gameObject);
        }
    }
}

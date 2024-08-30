using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArea : MonoBehaviour
{
    private bool isCollidingWithPlayer = false; // 플레이어와의 충돌 상태 저장
    private static HashSet<string> destroyedObjects = new HashSet<string>(); // 삭제된 오브젝트를 저장할 static 변수
    public string uniqueIdentifier; // 고유 식별자

    private Collider2D objectCollider;

    private void Awake()
    {
        // 씬 전환 시 현재 오브젝트를 파괴하지 않도록 설정
        DontDestroyOnLoad(this.gameObject);

        objectCollider = GetComponent<Collider2D>();

        // 동일한 식별자를 가진 다른 오브젝트가 있는지 확인
        ItemArea[] existingObjects = FindObjectsOfType<ItemArea>();
        foreach (var obj in existingObjects)
        {
            if (obj != this && obj.uniqueIdentifier == uniqueIdentifier)
            {
                Destroy(gameObject); // 동일한 식별자를 가진 오브젝트가 있으면 현재 오브젝트를 파괴
                return;
            }
        }

        // 삭제된 상태인지 확인
        if (destroyedObjects.Contains(uniqueIdentifier))
        {
            Destroy(gameObject); // 이미 삭제된 상태라면 파괴
        }
    }

    private void Update()
    {
        // 현재 씬에 따라 트리거 스위치 온오프
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            objectCollider.isTrigger = true; // 3번째 씬에서는 트리거 활성화
        }
        else if (currentSceneIndex == 2)
        {
            objectCollider.isTrigger = false; // 4번째 씬에서는 트리거 비활성화
        }

        // F 키를 누르고 있으며, 플레이어가 충돌 중이고, Item의 itemCount가 0보다 큰 경우
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.F) && Item.itemCount > 0)
        {
            // itemCount 감소
            Item.itemCount--;
            Debug.Log("ItemArea destroyed. Remaining itemCount: " + Item.itemCount);

            // 현재 itemArea 오브젝트 파괴
            destroyedObjects.Add(uniqueIdentifier); // 삭제된 오브젝트 기록
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectCollider.isTrigger && other.CompareTag("Player"))
        {
            Debug.Log("Player entered ItemArea");
            isCollidingWithPlayer = true; // 플레이어와 충돌 상태 설정
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited ItemArea");
            isCollidingWithPlayer = false; // 플레이어가 충돌에서 벗어나면 충돌 상태 해제
        }
    }

    private void OnApplicationQuit()
    {
        // 게임 종료 시 삭제된 오브젝트 정보 초기화
        destroyedObjects.Clear();
    }
}

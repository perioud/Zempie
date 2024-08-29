using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    public string uniqueIdentifier; // 고유 식별자
    private static HashSet<string> destroyedObjects = new HashSet<string>(); // 삭제된 오브젝트를 저장할 static 변수

    public bool triggerEnabledInScene0 = true; // 0번째 씬에서 트리거가 활성화되는지 여부
    public bool triggerEnabledInScene1 = false; // 1번째 씬에서 트리거가 비활성화되는지 여부

    private Collider2D objectCollider;
    private bool isCollidingWithPlayer = false; // 플레이어와의 충돌 상태 저장

    private void Awake()
    {
        // 씬 전환 시 현재 오브젝트를 파괴하지 않도록 설정
        DontDestroyOnLoad(this.gameObject);

        objectCollider = GetComponent<Collider2D>();

        // 동일한 식별자를 가진 다른 오브젝트가 있는지 확인
        DontDestroyOnLoadManager[] existingObjects = FindObjectsOfType<DontDestroyOnLoadManager>();
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
        if (currentSceneIndex == 0)
        {
            objectCollider.isTrigger = triggerEnabledInScene0; // 0번째 씬에서는 트리거 활성화
        }
        else if (currentSceneIndex == 1)
        {
            objectCollider.isTrigger = triggerEnabledInScene1; // 1번째 씬에서는 트리거 비활성화
        }

        // 스페이스바 입력 상태 저장
        if (isCollidingWithPlayer && Input.GetKeyUp(KeyCode.Space))
        {
            destroyedObjects.Add(uniqueIdentifier);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectCollider.isTrigger && other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true; // 플레이어와 충돌 상태 설정
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false; // 플레이어가 충돌에서 벗어나면 충돌 상태 해제
        }
    }
}

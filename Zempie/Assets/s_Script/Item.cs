using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName; // 각 아이템마다 고유한 이름을 설정해 줍니다.
    public GameObject UI; // UI 오브젝트를 인스펙터에서 할당해야 합니다.
    public GameObject Trash;

    private Collider2D objectCollider;
    private bool isCollidingWithPlayer = false; // 플레이어와의 충돌 상태 저장

    // 아이템의 삭제 상태를 메모리 내에서 관리하는 static 변수
    private static HashSet<string> destroyedItems = new HashSet<string>();

    void Start()
    {
        // 아이템이 이미 파괴된 상태라면, 오브젝트를 파괴하고 함수 종료
        if (destroyedItems.Contains(itemName))
        {
            Destroy(gameObject);
            return;
        }

        // Collider2D 컴포넌트를 가져와서 초기화합니다.
        objectCollider = GetComponent<Collider2D>();

        // Collider2D가 없으면 오류 메시지를 출력합니다.
        if (objectCollider == null)
        {
            Debug.LogError("Collider2D component not found on this GameObject.");
        }

        // UI가 할당되지 않았을 경우 오류 메시지를 출력합니다.
        if (UI == null)
        {
            Debug.LogError("UI GameObject is not assigned.");
        }
    }

    void Update()
    {
        if (UI != null && gameObject.activeInHierarchy) // UI가 할당되고, 게임 오브젝트가 활성화된 경우에만 UI 상태를 변경합니다.
        {
            // 스페이스바 입력 상태 저장
            if (isCollidingWithPlayer && Input.GetKey(KeyCode.Space))
            {
                // UI를 활성화하고 아이템을 비활성화
                UI.SetActive(true);
                Destroy(UI, 2f);

                // 아이템의 파괴 상태를 메모리 내에 저장
                destroyedItems.Add(itemName);

                // 아이템 오브젝트 파괴
                Destroy(gameObject);
                Debug.Log("Item obtained and ItemOb deactivated.");

                Trash.SetActive(true);
            }
            else
            {
                // 충돌 중이 아니거나 스페이스바를 누르지 않았을 경우 UI를 비활성화
                UI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectCollider != null && objectCollider.isTrigger && other.CompareTag("Player"))
        {
            Debug.Log("Collision with Player: " + isCollidingWithPlayer);
            isCollidingWithPlayer = true; // 플레이어와 충돌 상태 설정
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited Collision with Player: " + isCollidingWithPlayer);
            isCollidingWithPlayer = false; // 플레이어가 충돌에서 벗어나면 충돌 상태 해제
        }
    }
}

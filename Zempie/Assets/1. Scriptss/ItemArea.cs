using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArea : MonoBehaviour
{
    private bool isCollidingWithPlayer = false; // �÷��̾���� �浹 ���� ����
    private static HashSet<string> destroyedObjects = new HashSet<string>(); // ������ ������Ʈ�� ������ static ����
    public string uniqueIdentifier; // ���� �ĺ���

    private Collider2D objectCollider;

    private void Awake()
    {
        // �� ��ȯ �� ���� ������Ʈ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(this.gameObject);

        objectCollider = GetComponent<Collider2D>();

        // ������ �ĺ��ڸ� ���� �ٸ� ������Ʈ�� �ִ��� Ȯ��
        ItemArea[] existingObjects = FindObjectsOfType<ItemArea>();
        foreach (var obj in existingObjects)
        {
            if (obj != this && obj.uniqueIdentifier == uniqueIdentifier)
            {
                Destroy(gameObject); // ������ �ĺ��ڸ� ���� ������Ʈ�� ������ ���� ������Ʈ�� �ı�
                return;
            }
        }

        // ������ �������� Ȯ��
        if (destroyedObjects.Contains(uniqueIdentifier))
        {
            Destroy(gameObject); // �̹� ������ ���¶�� �ı�
        }
    }

    private void Update()
    {
        // ���� ���� ���� Ʈ���� ����ġ �¿���
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            objectCollider.isTrigger = true; // 3��° �������� Ʈ���� Ȱ��ȭ
        }
        else if (currentSceneIndex == 2)
        {
            objectCollider.isTrigger = false; // 4��° �������� Ʈ���� ��Ȱ��ȭ
        }

        // F Ű�� ������ ������, �÷��̾ �浹 ���̰�, Item�� itemCount�� 0���� ū ���
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.F) && Item.itemCount > 0)
        {
            // itemCount ����
            Item.itemCount--;
            Debug.Log("ItemArea destroyed. Remaining itemCount: " + Item.itemCount);

            // ���� itemArea ������Ʈ �ı�
            destroyedObjects.Add(uniqueIdentifier); // ������ ������Ʈ ���
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectCollider.isTrigger && other.CompareTag("Player"))
        {
            Debug.Log("Player entered ItemArea");
            isCollidingWithPlayer = true; // �÷��̾�� �浹 ���� ����
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited ItemArea");
            isCollidingWithPlayer = false; // �÷��̾ �浹���� ����� �浹 ���� ����
        }
    }

    private void OnApplicationQuit()
    {
        // ���� ���� �� ������ ������Ʈ ���� �ʱ�ȭ
        destroyedObjects.Clear();
    }
}

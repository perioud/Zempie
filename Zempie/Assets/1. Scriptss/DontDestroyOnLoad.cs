using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    public string uniqueIdentifier; // ���� �ĺ���
    private static HashSet<string> destroyedObjects = new HashSet<string>(); // ������ ������Ʈ�� ������ static ����

    public bool triggerEnabledInScene0 = true; // 0��° ������ Ʈ���Ű� Ȱ��ȭ�Ǵ��� ����
    public bool triggerEnabledInScene1 = false; // 1��° ������ Ʈ���Ű� ��Ȱ��ȭ�Ǵ��� ����

    private Collider2D objectCollider;
    private bool isCollidingWithPlayer = false; // �÷��̾���� �浹 ���� ����

    private void Awake()
    {
        // �� ��ȯ �� ���� ������Ʈ�� �ı����� �ʵ��� ����
        DontDestroyOnLoad(this.gameObject);

        objectCollider = GetComponent<Collider2D>();

        // ������ �ĺ��ڸ� ���� �ٸ� ������Ʈ�� �ִ��� Ȯ��
        DontDestroyOnLoadManager[] existingObjects = FindObjectsOfType<DontDestroyOnLoadManager>();
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
        if (currentSceneIndex == 0)
        {
            objectCollider.isTrigger = triggerEnabledInScene0; // 0��° �������� Ʈ���� Ȱ��ȭ
        }
        else if (currentSceneIndex == 1)
        {
            objectCollider.isTrigger = triggerEnabledInScene1; // 1��° �������� Ʈ���� ��Ȱ��ȭ
        }

        // �����̽��� �Է� ���� ����
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
            isCollidingWithPlayer = true; // �÷��̾�� �浹 ���� ����
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false; // �÷��̾ �浹���� ����� �浹 ���� ����
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName; // �� �����۸��� ������ �̸��� ������ �ݴϴ�.
    public GameObject UI; // UI ������Ʈ�� �ν����Ϳ��� �Ҵ��ؾ� �մϴ�.
    public GameObject Trash;

    private Collider2D objectCollider;
    private bool isCollidingWithPlayer = false; // �÷��̾���� �浹 ���� ����

    // �������� ���� ���¸� �޸� ������ �����ϴ� static ����
    private static HashSet<string> destroyedItems = new HashSet<string>();

    void Start()
    {
        // �������� �̹� �ı��� ���¶��, ������Ʈ�� �ı��ϰ� �Լ� ����
        if (destroyedItems.Contains(itemName))
        {
            Destroy(gameObject);
            return;
        }

        // Collider2D ������Ʈ�� �����ͼ� �ʱ�ȭ�մϴ�.
        objectCollider = GetComponent<Collider2D>();

        // Collider2D�� ������ ���� �޽����� ����մϴ�.
        if (objectCollider == null)
        {
            Debug.LogError("Collider2D component not found on this GameObject.");
        }

        // UI�� �Ҵ���� �ʾ��� ��� ���� �޽����� ����մϴ�.
        if (UI == null)
        {
            Debug.LogError("UI GameObject is not assigned.");
        }
    }

    void Update()
    {
        if (UI != null && gameObject.activeInHierarchy) // UI�� �Ҵ�ǰ�, ���� ������Ʈ�� Ȱ��ȭ�� ��쿡�� UI ���¸� �����մϴ�.
        {
            // �����̽��� �Է� ���� ����
            if (isCollidingWithPlayer && Input.GetKey(KeyCode.Space))
            {
                // UI�� Ȱ��ȭ�ϰ� �������� ��Ȱ��ȭ
                UI.SetActive(true);
                Destroy(UI, 2f);

                // �������� �ı� ���¸� �޸� ���� ����
                destroyedItems.Add(itemName);

                // ������ ������Ʈ �ı�
                Destroy(gameObject);
                Debug.Log("Item obtained and ItemOb deactivated.");

                Trash.SetActive(true);
            }
            else
            {
                // �浹 ���� �ƴϰų� �����̽��ٸ� ������ �ʾ��� ��� UI�� ��Ȱ��ȭ
                UI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectCollider != null && objectCollider.isTrigger && other.CompareTag("Player"))
        {
            Debug.Log("Collision with Player: " + isCollidingWithPlayer);
            isCollidingWithPlayer = true; // �÷��̾�� �浹 ���� ����
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited Collision with Player: " + isCollidingWithPlayer);
            isCollidingWithPlayer = false; // �÷��̾ �浹���� ����� �浹 ���� ����
        }
    }
}

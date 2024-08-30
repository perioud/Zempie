using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject a; // ������ ������Ʈ A
    private bool hasCreatedA = false; // ������Ʈ A�� �����Ǿ����� ����

    void Update()
    {
        // ��� ItemArea ������Ʈ�� ��������� �˻�
        if (!hasCreatedA && AreAllItemAreasGone())
        {
            a.SetActive(true);
        }
    }

    private bool AreAllItemAreasGone()
    {
        // ItemArea �±׸� ���� ��� ������Ʈ�� �����ϴ��� �˻�
        ItemArea[] itemAreas = FindObjectsOfType<ItemArea>();
        return itemAreas.Length == 0;
    }

}

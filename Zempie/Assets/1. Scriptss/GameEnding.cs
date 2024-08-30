using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject a; // 생성할 오브젝트 A
    private bool hasCreatedA = false; // 오브젝트 A가 생성되었는지 여부

    void Update()
    {
        // 모든 ItemArea 오브젝트가 사라졌는지 검사
        if (!hasCreatedA && AreAllItemAreasGone())
        {
            a.SetActive(true);
        }
    }

    private bool AreAllItemAreasGone()
    {
        // ItemArea 태그를 가진 모든 오브젝트가 존재하는지 검사
        ItemArea[] itemAreas = FindObjectsOfType<ItemArea>();
        return itemAreas.Length == 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private float time;
    [SerializeField] private float curTime;

    int minute;
    int second;
    private static Timer instance;

    private void Awake()
    {
        // �� ��ȯ �ÿ��� Ÿ�̸Ӱ� �����ǵ��� �ϱ�
        DontDestroyOnLoad(gameObject);

        // ����� Ÿ�̸� �� �ҷ�����
        if (PlayerPrefs.HasKey("SavedTime"))
        {
            curTime = PlayerPrefs.GetFloat("SavedTime");
        }
        else
        {
            curTime = time;
        }

        StartCoroutine(StartTimer());

        void OnDestroy()
        {
            // Ÿ�̸� ���� �� ���� ����
            PlayerPrefs.SetFloat("SavedTime", curTime);
        }

        time = 180;
        StartCoroutine(StartTimer());
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StartTimer()
    {
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            text.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if (curTime <= 0)
            {
                Debug.Log("�ð� ����");
                curTime = 0;
                yield break;
            }
        }
    }
}

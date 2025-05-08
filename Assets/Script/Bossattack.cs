using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Bossattack : MonoBehaviour
{
    public Ddong prefabMop; //Ÿ�� ������ �ް�
    public GameObject SpawnPoints;

    private List<Ddong> MopPool = new List<Ddong>(); //Ÿ���� ���� ������ ����°ǰ�

    private readonly int mopMaxCount = 4; //���� ����
    private int curMopIndex = 0;


    private float SpawnInterval = 1f;  // 1�� ����
    private float LastSpawnTime = 0f;
    void Start()
    {
        for (int i = 0; i < mopMaxCount; i++) //ī��Ʈ ��ŭ �����ϰ�
        {
            Ddong b = Instantiate<Ddong>(prefabMop);
                
            b.gameObject.SetActive(false); //�ϴ� ��Ȱ��ȭ ���ѵΰ�
            MopPool.Add(b);
        }
    }

    void Update()
    {
        if (Time.time - LastSpawnTime >= SpawnInterval)
        {
            mopspawn();
            LastSpawnTime = Time.time;  // ������ ���� �ð� ����
        }
    }
    void mopspawn()
    {
        if (MopPool[curMopIndex].gameObject.activeSelf)
        {
            return;
        }

        Bounds bounds = SpawnPoints.GetComponent<Renderer>().bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ); //Ȱ��ȭ ��ġ��

        MopPool[curMopIndex].transform.position = randomPosition; //Ȱ��ȭ ��ġ

        MopPool[curMopIndex].gameObject.SetActive(true);

        if (curMopIndex >= mopMaxCount - 1)
        {
            curMopIndex = 0;
        }
        else
        {
            curMopIndex++;
        }
    }


}

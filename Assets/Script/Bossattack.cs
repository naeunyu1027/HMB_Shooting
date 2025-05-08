using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class Bossattack : MonoBehaviour
{
    public Ddong prefabMop; //타켓 프리팹 받고
    public GameObject SpawnPoints;

    private List<Ddong> MopPool = new List<Ddong>(); //타겟이 있을 공간을 만드는건가

    private readonly int mopMaxCount = 4; //생성 갯수
    private int curMopIndex = 0;


    private float SpawnInterval = 1f;  // 1초 간격
    private float LastSpawnTime = 0f;
    void Start()
    {
        for (int i = 0; i < mopMaxCount; i++) //카운트 만큼 생성하고
        {
            Ddong b = Instantiate<Ddong>(prefabMop);
                
            b.gameObject.SetActive(false); //일단 비활성화 시켜두고
            MopPool.Add(b);
        }
    }

    void Update()
    {
        if (Time.time - LastSpawnTime >= SpawnInterval)
        {
            mopspawn();
            LastSpawnTime = Time.time;  // 마지막 스폰 시간 갱신
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
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ); //활성화 위치값

        MopPool[curMopIndex].transform.position = randomPosition; //활성화 위치

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class ObjectPooling : MonoBehaviour
{
    public Target prefabTarget; //타켓 프리팹 받고
    public GameObject spawnPoints;

    private List<Target> targetPool = new List<Target>(); //타겟이 있을 공간을 만드는건가

    private readonly int targetMaxCount = 6; //생성 갯수
    private int curTargetIndex = 0;


    private float spawnInterval = 0.4f;  // 1초 간격
    private float lastSpawnTime = 0f;
    void Start()
    {
        for(int i = 0; i< targetMaxCount; i++) //카운트 만큼 생성하고
        {
            Target b = Instantiate<Target>(prefabTarget);

            b.gameObject.SetActive(false); //일단 비활성화 시켜두고
            targetPool.Add(b);
        }
    }

    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            targetspawn();
            lastSpawnTime = Time.time;  // 마지막 스폰 시간 갱신
        }
    }
    void targetspawn()
    {
            if (targetPool[curTargetIndex].gameObject.activeSelf)
            {
            return;
        }

        Bounds bounds = spawnPoints.GetComponent<Renderer>().bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ); //활성화 위치값

            targetPool[curTargetIndex].transform.position = randomPosition; //활성화 위치

            targetPool[curTargetIndex].gameObject.SetActive(true);

            if(curTargetIndex >= targetMaxCount - 1)
            {
                curTargetIndex = 0;
            }
            else
            {
                curTargetIndex++;
            }
    }

    //https://glikmakesworld.tistory.com/13

}

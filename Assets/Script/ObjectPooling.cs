using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class ObjectPooling : MonoBehaviour
{
    public Target prefabTarget; //Ÿ�� ������ �ް�
    public GameObject spawnPoints;

    private List<Target> targetPool = new List<Target>(); //Ÿ���� ���� ������ ����°ǰ�

    private readonly int targetMaxCount = 6; //���� ����
    private int curTargetIndex = 0;


    private float spawnInterval = 0.4f;  // 1�� ����
    private float lastSpawnTime = 0f;
    void Start()
    {
        for(int i = 0; i< targetMaxCount; i++) //ī��Ʈ ��ŭ �����ϰ�
        {
            Target b = Instantiate<Target>(prefabTarget);

            b.gameObject.SetActive(false); //�ϴ� ��Ȱ��ȭ ���ѵΰ�
            targetPool.Add(b);
        }
    }

    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            targetspawn();
            lastSpawnTime = Time.time;  // ������ ���� �ð� ����
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
        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ); //Ȱ��ȭ ��ġ��

            targetPool[curTargetIndex].transform.position = randomPosition; //Ȱ��ȭ ��ġ

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject[] slimes;
    public float slimeInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
        
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnSlimeRoutine());
    }

    void StopSpawning()
    {
        StopCoroutine(SpawnSlimeRoutine());
    }

    IEnumerator SpawnSlimeRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        while(true)
        {
            SpawnSlime();
            yield return new WaitForSeconds(slimeInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSlime()
    {
        //�������� ������ ��ġ ����
        //x���� ���� �������� �����Ѵ�
        float posX = Random.Range(-3f, 3f);       
        Vector3 position = new Vector3(posX, 6, 0);

        //������ ������ ������ ����
        //�������� ������ ������ �迭�� �ε����� ����
        int index = Random.Range(0, slimes.Length);
        Instantiate(slimes[index], position, Quaternion.identity);
    }
}

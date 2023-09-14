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
        StartCoroutine("SpawnSlimeRoutine");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnSlimeRoutine");
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
        //슬라임이 떨어질 위치 지정
        //x축의 값을 랜덤으로 지정한다
        float posX = Random.Range(-3f, 3f);       
        Vector3 position = new Vector3(posX, 6, 0);

        //스폰할 슬라임 프리팹 생성
        //랜덤으로 스폰할 슬라임 배열의 인덱스값 설정
        int index = Random.Range(0, slimes.Length);
        Instantiate(slimes[index], position, Quaternion.identity);
    }

    public void DecreaseSlimeInterval()
    {
        slimeInterval -= 0.2f;
        if(slimeInterval <= 0.2f ) {
            //계속 감소하다가 0 이하로 떨어지지 않도록 0.1f로 고정
            slimeInterval = 0.1f;
        }
    }
}

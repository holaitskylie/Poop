using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false; //게임 오버 상태
    [SerializeField]
    private Text scoreText; //점수를 출력할 UI 텍스트
    [SerializeField]
    private GameObject gameoverUI; //게임오버 시 활성화할 UI 게임 오브젝트
    [SerializeField]
    private Text recordText; //최고 기록을 표시할 텍스트

    private int score = 0;


    //게임 시작과 동시에 싱글턴 구성
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버 상태에서 게임을 재시작 할 수 있게 하는 처리
        if(isGameover)
        {
            //게임 오버 UI 활성화
            gameoverUI.SetActive(true);
            
        }
        
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;

            if (score % 10 == 0)
            {
                SlimeSpawner spawner = FindObjectOfType<SlimeSpawner>();
                if (spawner != null)
                {
                    //spawner을 가져오는데 성공했다면
                    spawner.DecreaseSlimeInterval();
                    Debug.Log("Level Upgrade");

                }
            }

        }        

    }

    //플레이어 캐릭터 사망 시 게임 오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        //현재 상태를 게임 오버 상태로 변경
        isGameover = true;

        SlimeSpawner spawner = FindObjectOfType<SlimeSpawner>();
        if(spawner != null ) 
        {
            //슬라임 생성 중지
            spawner.StopSpawning();
        }

        //BestScore 키로 저장된 이전까지의 최고 기록 가져오기
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(score> bestScore)
        {
            //이전까지의 최고 점수보다 현재 점수가 더 높다면
            //최고 점수 기록 값을 현재 점수 값으로 변경
            bestScore = score;

            //변경된 최고 기록을 BestScore 키로 저장
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        //최고 점수를 recordText 텍스트를 이용해 표시
        recordText.text = " " + (int)bestScore;
    }

    public void Reload()
    {
        //현재 씬 재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameExit()
    {
        Application.Quit();
    }
}

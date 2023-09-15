using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false; //���� ���� ����
    [SerializeField]
    private Text scoreText; //������ ����� UI �ؽ�Ʈ
    [SerializeField]
    private GameObject gameoverUI; //���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ
    [SerializeField]
    private Text recordText; //�ְ� ����� ǥ���� �ؽ�Ʈ

    private int score = 0;


    //���� ���۰� ���ÿ� �̱��� ����
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
        //���� ���� ���¿��� ������ ����� �� �� �ְ� �ϴ� ó��
        if(isGameover)
        {
            //���� ���� UI Ȱ��ȭ
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
                    //spawner�� �������µ� �����ߴٸ�
                    spawner.DecreaseSlimeInterval();
                    Debug.Log("Level Upgrade");

                }
            }

        }        

    }

    //�÷��̾� ĳ���� ��� �� ���� ������ �����ϴ� �޼���
    public void OnPlayerDead()
    {
        //���� ���¸� ���� ���� ���·� ����
        isGameover = true;

        SlimeSpawner spawner = FindObjectOfType<SlimeSpawner>();
        if(spawner != null ) 
        {
            //������ ���� ����
            spawner.StopSpawning();
        }

        //BestScore Ű�� ����� ���������� �ְ� ��� ��������
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(score> bestScore)
        {
            //���������� �ְ� �������� ���� ������ �� ���ٸ�
            //�ְ� ���� ��� ���� ���� ���� ������ ����
            bestScore = score;

            //����� �ְ� ����� BestScore Ű�� ����
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        //�ְ� ������ recordText �ؽ�Ʈ�� �̿��� ǥ��
        recordText.text = " " + (int)bestScore;
    }

    public void Reload()
    {
        //���� �� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameExit()
    {
        Application.Quit();
    }
}

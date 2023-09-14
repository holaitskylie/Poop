using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    private AudioSource audio;
    private SpriteRenderer renderer;
    

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.gameObject.tag == "Slime" || other.gameObject.tag == "Background")
        {
            //slime, Background �±׸� ���� ������Ʈ���� �浹 ó�� ����
            return;
        }
        else if (other.gameObject.tag == "Ground")
        {
            //����� �浹�ϸ� GamaManager�� �ν��Ͻ��� ���� AddScore�� newScore ���ڰ����� 1 ����
            GameManager.instance.AddScore(1);        
            
        }
        else if(other.gameObject.tag == "Player")
        {
            //�÷��̾� ĳ���Ϳ� �浹�ϸ� ���� ���� ó��
            GameManager.instance.OnPlayerDead();

            //�÷��̾��� �÷����� �ٲٴ� �޼��� ����
            other.gameObject.GetComponent<PlayerMove>().GetSlime();
        }

        //��ƼŬ ����Ʈ ���
        Instantiate(particle, transform.position, Quaternion.identity);

        //�浹���� ��, ����� ���
        audio.Play();

        //�浹���� ��, ��������Ʈ ������ ������Ʈ�� ��Ȱ��ȭ �Ͽ� ���� ������Ʈ�� �ٷ� ����� ���� ȿ���� �ش�
        renderer.enabled = false;

        //�浹�� ������Ʈ�� "Ground" �±׸� �����ٸ� ������ ������Ʈ ����
        //����� ����� ���Ͽ� 1�� �ڿ� ���� ������Ʈ ����
        Destroy(gameObject, 1f);


    }
}

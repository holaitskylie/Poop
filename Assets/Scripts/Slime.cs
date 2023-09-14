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
            //slime, Background 태그를 가진 오브젝트와의 충돌 처리 무시
            return;
        }
        else if (other.gameObject.tag == "Ground")
        {
            //지면과 충돌하면 GamaManager의 인스턴스를 통해 AddScore의 newScore 인자값으로 1 전달
            GameManager.instance.AddScore(1);        
            
        }
        else if(other.gameObject.tag == "Player")
        {
            //플레이어 캐릭터와 충돌하면 게임 오버 처리
            GameManager.instance.OnPlayerDead();

            //플레이어의 컬러값을 바꾸는 메서드 실행
            other.gameObject.GetComponent<PlayerMove>().GetSlime();
        }

        //파티클 이펙트 재생
        Instantiate(particle, transform.position, Quaternion.identity);

        //충돌했을 때, 오디오 재생
        audio.Play();

        //충돌했을 때, 스프라이트 렌더러 컴포넌트를 비활성화 하여 게임 오브젝트가 바로 사라진 듯한 효과를 준다
        renderer.enabled = false;

        //충돌한 오브젝트가 "Ground" 태그를 가졌다면 슬라임 오브젝트 삭제
        //오디오 재생을 위하여 1초 뒤에 게임 오브젝트 삭제
        Destroy(gameObject, 1f);


    }
}

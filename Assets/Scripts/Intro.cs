using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;    
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private bool isFacingRight = false; //오브젝트가 오른쪽을 향하는 지 여부
        
    void Start()
    {
        //spriteRenderer에 대한 참조를 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        //isFacingRight 값에 따라 게임 오브젝트를 좌우 이동 시킨다
        if (isFacingRight==false)
        {
            //왼쪽으로 이동 속도 * 시간만큼 이동
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if(isFacingRight==true)
        {
            //오른쪽으로 이동 속도 * 시간만큼 이동
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftCollider")
        {
            //Sprite Renderer 좌우 반전
            spriteRenderer.flipX = true;
            isFacingRight = true;          
            
        }
        else if (other.gameObject.tag == "RightCollider")
        {
            spriteRenderer.flipX = false;
            isFacingRight = false;
            
        }
        

    }
}

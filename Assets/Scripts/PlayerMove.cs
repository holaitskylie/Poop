using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //왼쪽 이동
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            //애니메이션 전환 조건 실행
            animator.SetBool("Walk", true);

            //이미지의 좌우반전
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            //오른쪽 이동
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            //애니메이션 전환 조건 실행
            animator.SetBool("Walk", true);

            //이미지의 좌우반전
            spriteRenderer.flipX = true; 
        }
        else
        {   //아무런 키 입력이 없는 경우, Idle 애니메이션 실행
            animator.SetBool("Walk", false);
        }
        
    }
}

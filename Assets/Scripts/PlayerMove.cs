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
            //���� �̵�
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            //�ִϸ��̼� ��ȯ ���� ����
            animator.SetBool("Walk", true);

            //�̹����� �¿����
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.RightArrow)) {
            //������ �̵�
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            //�ִϸ��̼� ��ȯ ���� ����
            animator.SetBool("Walk", true);

            //�̹����� �¿����
            spriteRenderer.flipX = true; 
        }
        else
        {   //�ƹ��� Ű �Է��� ���� ���, Idle �ִϸ��̼� ����
            animator.SetBool("Walk", false);
        }
        
    }
}

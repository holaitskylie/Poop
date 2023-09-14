using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;    
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private bool isFacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight==false)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else if(isFacingRight==true)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftCollider")
        {
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

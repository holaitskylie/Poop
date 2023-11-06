using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; //배경화면의 이동 속도

    private float posX; //배경의 가로 길이


    // Start is called before the first frame update
    void Start()
    {
        //posX의 값을 BoxCollider2D 컴포넌트의 Size x값으로 구한다
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        posX = backgroundCollider.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 방향으로 moveSpeed만큼 이동한다
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        //현재 위치가 원점에서 왼쪽으로 posX 이상 이동 했을 때 재배치
        if (transform.position.x <= -posX)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        //offset 현재 위치에서 얼마만큼 오른쪽으로 밀어낼지 저장할 변수
        Vector2 offset = new Vector2(posX * 2f, 0);
        transform.position = (Vector2)transform.position + offset;

    }
}

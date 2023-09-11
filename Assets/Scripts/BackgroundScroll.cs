using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; //���ȭ���� �̵� �ӵ�

    private float posX; //����� ���� ����


    // Start is called before the first frame update
    void Start()
    {
        //posX�� ���� BoxCollider2D ������Ʈ�� Size x������ ���Ѵ�
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        posX = backgroundCollider.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        //���� �������� moveSpeed��ŭ �̵��Ѵ�
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        //���� ��ġ�� �������� �������� posX �̻� �̵� ���� �� ���ġ
        if (transform.position.x <= -posX)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        //offset ���� ��ġ���� �󸶸�ŭ ���������� �о�� ������ ����
        Vector2 offset = new Vector2(posX * 2f, 0);
        transform.position = (Vector2)transform.position + offset;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //画像
    public Texture2D m_texture = null;
    //Sprite
    Sprite m_sprite;
    //true 動く, false 止まる
    bool move = false;
    //初期位置
    Vector2 firstPos;
    //扉の移動先
    Vector2 nextPos;
    //扉の開く大きさ
    float open = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = this.gameObject.transform.position;
        nextPos = this.gameObject.transform.position;
        nextPos.y = nextPos.y + open;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            Move();

        }
    }

    private void Move()
    {
        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, nextPos, 0.1f);

        float dist = Vector2.Distance(this.gameObject.transform.position, nextPos);

        if(dist <= 0)
        {
            move = false;
        }
    }

    public void ToMove(bool up)
    {
        //動かす
        move = true;

        //扉の開閉の位置を入れる
        if (up)
        {
            nextPos = firstPos;
            nextPos.y += open;
        }
        else
        {
            nextPos = firstPos;
        }
    }
}

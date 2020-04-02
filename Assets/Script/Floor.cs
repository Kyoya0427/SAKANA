using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    //true 動く, false 止まる
    bool move = false;
    //床の伸びる量
    public float length = 0.0f;
    //初期位置
    Vector2 firstPos;
    //床の伸びる先
    Vector2 nextPos;
    //伸びるスケール
    float scale = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        firstPos = this.gameObject.transform.position;
        scale = (firstPos.x + length) / firstPos.x;
        nextPos = new Vector2(firstPos.x + length, firstPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            Move();
        }
    }
    
    //作動
    private void Move()
    {
        //目的場所まで伸ばす
        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, nextPos, 0.1f);

        //現在地から目的地までの距離を算出
        float dist = Vector2.Distance(this.gameObject.transform.position, nextPos);

        //目的場所に到達したら止める
        if (dist <= 0)
        {
            move = false;
        }

    }

    public void ToMove(bool operate)
    {
        //動かす
        move = true;

        //床の伸び先の位置を入れる
        if (operate)
        {
            nextPos = firstPos;
            nextPos.x = firstPos.x + length;
        }
        else
        {
            nextPos = firstPos;
        }
    }
}

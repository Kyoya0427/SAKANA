using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 SPEED = new Vector2(0.3f, 0.3f);
    float jumpForce = 390.0f;       // ジャンプ時に加える力
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rb.AddForce(transform.up * this.jumpForce);
        }
        
        Move();
    }

    // 移動関数
    void Move()
    {
        // 現在位置をPositionに代入
        Vector2 Position = transform.position;
        // 左キーを押し続けていたら
        if (Input.GetKey("left"))
        {
            // 代入したPositionに対して加算減算を行う
            Position.x -= SPEED.x;
        }
        else if (Input.GetKey("right"))
        { // 右キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.x += SPEED.x;
        }
        else if (Input.GetKey("up"))
        { // 上キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y += SPEED.y;
        }
        else if (Input.GetKey("down"))
        { // 下キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y -= SPEED.y;
        }
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

}

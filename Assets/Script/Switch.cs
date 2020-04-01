using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //一度だけ押すだけで開く true, 押してる間だけ開く false
    public bool once = false;
    //対応するドア
    public GameObject door = null;
    //押されているか
    bool pushed = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //押されたらYスケールを小さく
        if(pushed)
        {
            this.gameObject.transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーに押された
        if (collision.gameObject.tag == "Player")
        {
            //押された状態に
            pushed = true;

            //扉を開ける
            door.GetComponent<Door>().ToMove(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //押すのが一度でよければ今後は処理しない
        if (once)
            return;

        //押されてない状態に
        pushed = false;

        //扉を閉める
        door.GetComponent<Door>().ToMove(false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}

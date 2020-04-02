using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //カメラの中心
    Vector3 m_center;
    //カメラのX座標の中心
    //float m_centerX = 4.5f;
    float m_centerX = 0.0f;
    //カメラのターゲット
    public GameObject m_target = null;
    //ゆっくり追従するスピード
    Vector3 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        //カメラの中心座標の作成
        m_center = new Vector3(m_centerX, 0.0f, 0.0f);

        //追従速度の設定
        m_velocity = new Vector3(0.3f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        //ターゲットが無ければ更新はしない
        if (!m_target)
            return;

        //LSfhit押されてない場合向きによってカメラをずらす
        //if (!Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        m_center.x = m_centerX * Input.GetAxisRaw("Horizontal");
        //    }
        //}

        //ベクトル作成
        Vector3 eye = new Vector3(m_target.transform.position.x,
            this.gameObject.transform.position.y, this.gameObject.transform.position.z) + m_center;

        ////ターゲットを追従
        //this.gameObject.transform.position = eye;

        //カメラ追従
        transform.position = Vector3.Lerp(this.gameObject.transform.position, eye + m_velocity, 4.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Invisible")
        {

        }
    }
}

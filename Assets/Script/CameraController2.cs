using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    //追従するターゲット
    public GameObject m_target = null;
    //一画面の横サイズ
    float m_width = 16.0f;
    //一画面の縦サイズ
    float m_height = 10.0f;
    //画面切り替えするスピード
    Vector3 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        //画面切り替えするスピードの設定
        m_velocity = new Vector3(0.3f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //現在のターゲットの区間の計算
        float w_interval = Mathf.Floor((m_target.transform.position.x + m_width / 2) / m_width);
        float h_interval = Mathf.Floor((m_target.transform.position.y + m_height / 2) / m_height);

        //ターゲットの現在位置の区間に対応するカメラの位置を作成
        Vector3 pos = new Vector3(m_width * w_interval, m_height * h_interval, -10.0f);

        //カメラの位置を区間ごとに分ける
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position,
            pos, 4.0f * Time.deltaTime);
    }
}

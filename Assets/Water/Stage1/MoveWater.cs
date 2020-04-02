using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour
{
    private float _moveSpeed;    //移動スピード
    private bool  _isMove;       //移動するかしないか
    GameObject    _playerPos;    //
    GameObject    _moveWaterPos;
    Vector3       _velpcity;
    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = 0.005f;
        _playerPos = GameObject.Find("Player");
        _moveWaterPos = GameObject.Find("動く水");

       
    }

    // Update is called once per frame
    void Update()
    {
        if(_isMove == true)
        {
            _velpcity += (_playerPos.transform.position - _moveWaterPos.transform.position) * _moveSpeed;
            _velpcity = new Vector3(_velpcity.x, 0.0f, 0.0f);
            _moveWaterPos.transform.position += _velpcity *Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _isMove = false;
        }
    }
}

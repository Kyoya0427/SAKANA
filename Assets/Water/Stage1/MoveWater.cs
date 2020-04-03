using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour
{
    private float _moveSpeed;    //移動スピード
    private bool  _isMove;       //移動するかしないか 
    private float _attenuation;
    GameObject    _playerPos;    //
    GameObject    _moveWater;
    Vector3       _velpcity;
    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = 1.0f;
        _attenuation = 0.5f;
        _playerPos = GameObject.Find("Player");
        _moveWater = GameObject.Find("MovingWater1");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(_isMove == true)
        {
            _velpcity += (_playerPos.transform.position - _moveWater.transform.position) * _moveSpeed;
            _velpcity *= _attenuation;
            _velpcity = new Vector3(_velpcity.x, 0.0f, 0.0f);
            _moveWater.transform.position += _velpcity * Time.deltaTime;
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

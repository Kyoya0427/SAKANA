using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishProduction : MonoBehaviour
{
    const float INTERVAL = 5.0f;
    const int MAX_ENEMY_NUM = 5;
    float _createInterval;
    int  _enemyCount;
    bool _isInScreen;
    GameObject _enemy;
    GameObject[] tagObjects;
    // Start is called before the first frame update
    void Start()
    {
        _createInterval = 0.0f;
        _enemy = GameObject.FindWithTag("Enemy");
        _isInScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        Renderer render = this.gameObject.GetComponent<Renderer>();
        Check("Enemy");
       
        if (render.isVisible)
        {
            _isInScreen = true;
        }
        else
        {
            _isInScreen = false;
        }


        if (_isInScreen == true)
        {
            _createInterval += Time.deltaTime;

            if (_createInterval >= INTERVAL && _enemyCount <= MAX_ENEMY_NUM)
            {
                _createInterval = 0.0f;
                Instantiate(_enemy, this.transform.position, Quaternion.identity);
                Debug.Log(this.transform.position);
            }
        }

    }

    void Check(string tagname)
    {

        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        _enemyCount = tagObjects.Length;
    }
}

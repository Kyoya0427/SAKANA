using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaterAstar : MonoBehaviour
{
    public NavMeshAgent _water;
    public GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        _water = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _water.destination = _target.transform.position;
        }
    }
}

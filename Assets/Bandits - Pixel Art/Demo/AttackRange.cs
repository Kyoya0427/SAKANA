using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField]
    string user;

    [SerializeField]
    string attackTag;

    private int atk = 0;
    private bool isAttack = false;

    private float power = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        atk = GameObject.Find(user).GetComponent<Actor>().GetAtk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(string direction)
    {
        isAttack = true;

        if (direction == "Left") power = -5.0f;
        if (direction == "Right") power = 5.0f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isAttack)
        {
            if (other.tag != attackTag) return;
            GameObject obj = other.gameObject;
            Actor actor = obj.GetComponent<Actor>();
            actor.Damage(atk);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(power, 0.0f));
        }
        isAttack = false;
    }
}

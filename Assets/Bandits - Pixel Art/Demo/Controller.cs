using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // 移動速度
    [SerializeField]
    float vel = 1.0f;
    // ジャンプ力
    [SerializeField]
    float jumpForce = 1.0f;

    private enum State
    {
        NONE,

        WAIT,       // 待機中
        RUN,        // 走っている
        JUMP,       // ジャンプ中
        ATTACK,     // 攻撃中
        FALL,       // 落下
        HIT,        // 被弾
        DEAD,       // 死んだ

        NUM_STATE,
    }

    private Animator animator;              // アニメーター
    private Rigidbody2D rigid2d;            // あれ
    private GroundedSensor grounded;        // 地面
    private Transform trans;                // オブジェクトの座標など
    private float scaleX;                   // オブジェクトの方向
    private State state = State.WAIT;       // ステート

    // 攻撃連打をさせたくない
    private const float ATTACK_TIMER = 1f * 25f; // 定数
    private float atkTimer = 0.0f;  // 次の攻撃ができるまでのカウント

    // キャラクター情報
    Actor actor;
    // 攻撃を行うやつ
    AttackRange attack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2d = GetComponent<Rigidbody2D>();
        grounded = transform.Find("GroundSensor").GetComponent<GroundedSensor>();
        trans = GetComponent<Transform>();
        scaleX = this.trans.localScale.x;
        actor = GetComponent<Actor>();
        attack = transform.Find("AttackRange").GetComponent<AttackRange>();
    }

    // Update is called once per frame
    void Update()
    {
        // 地上にいるか
        animator.SetBool("Grounded", grounded.GetGrounded());

        // 攻撃中は操作不可
        if (atkTimer > 0.0f)
        {
            atkTimer--;
            return;
        }

        // 左右移動
        float inputX = Input.GetAxis("Horizontal");

        // 攻撃
        if (Input.GetKeyDown("z")) state = State.ATTACK;
        // ジャンプ
        else if (Input.GetKeyDown("space")) state = State.JUMP;
        // 移動
        else if (Mathf.Abs(inputX) > Mathf.Epsilon) state = State.RUN;
        // 何もしない
        else state = State.WAIT;
        
        // 落下中？
        if (grounded.GetGrounded() != true
            && state != State.ATTACK)
            state = State.FALL;

        // 死亡したか
        if (actor.GetHp() <= 0) state = State.DEAD;

        switch (state)
        {
            case State.NONE:
                break;
            case State.WAIT:
                animator.SetInteger("AnimState", 0);
                break;
            case State.RUN:
                Move(inputX);
                animator.SetInteger("AnimState", 2);
                break;
            case State.JUMP:
                Move(inputX);
                // 地面にいるならば
                if (grounded.GetGrounded())
                {
                    rigid2d.velocity = new Vector2(rigid2d.velocity.x, jumpForce);
                    animator.SetTrigger("Jump");
                }
                break;
            case State.ATTACK:
                animator.SetTrigger("Attack");
                attack.Attack("Right");
                atkTimer = ATTACK_TIMER;
                break;
            case State.FALL:
                Move(inputX);
                animator.SetTrigger("Jump");
                break;
            case State.HIT:
                animator.SetTrigger("Hurt");
                break;
            case State.DEAD:
                animator.SetTrigger("Death");
                break;
            default:
                break;
        }

        state = State.NONE;
    }

    private void Move(float iX)
    {

        // 移動方向
        if (iX > 0)
        {
            transform.localScale = new Vector3(-scaleX, trans.localScale.y, trans.localScale.z);
        }
        else if (iX < 0)
        {
            transform.localScale = new Vector3(scaleX, trans.localScale.y, trans.localScale.z);
        }
        // 移動
        rigid2d.velocity = new Vector2(iX * vel, rigid2d.velocity.y);
    }
}

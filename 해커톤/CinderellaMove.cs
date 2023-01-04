using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CinderellaMove : MonoBehaviour
{

    public float moveSpeed = 5.0f;

    public float gravity = -5.0f;
    float yVelocity = 0;

    public float jumpPower = 5.0f;
    public int maxJump = 2;
    int jumpCount = 0;

    CharacterController cc;

    public int hp;
    public int maxHp = 20;

    public Slider hpSlider;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        hp = maxHp;
    }   

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Go)
        {
            return;
        }


        float h = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(h, 0, 0);
        dir.Normalize();

        //점프 초기화
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            jumpCount = 0;
            yVelocity = 0;
        }


        if (Input.GetButtonDown("Jump") && jumpCount < maxJump)
        {
            jumpCount++;
            yVelocity = jumpPower;
        }

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        hpSlider.value = (float)hp / (float)maxHp;

    }

    //플레이어 피격 함수
    public void OnDamage(int value)
    {
        hp -= value;

        if (hp < 0)
        {
            hp = 0;     
        }

        else
        {
   
        }

    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
    public Vector3 direction;                  //2D에서의 던지는 무기 날아가는 방향
    public bool hasHit = false;
    public float speed = 10.0f;                 //날아가는 속도

    private void FixedUpdate()
    {
        if (!hasHit)
            GetComponent<Rigidbody2D>().velocity = direction * speed;   //히트시 넉백
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("ApplyDamage", Mathf.Sign(direction.x) * 2f); //오브젝트에 메세지를 보낸다
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

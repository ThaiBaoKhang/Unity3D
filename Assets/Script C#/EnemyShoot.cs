using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public GameObject fireball;

    Transform player;

    [SerializeField]
    public Transform shootPoint;

    float fireRate = 0.5f;

    [SerializeField]
    float turnSpeed = 5;

    private ColliderTrigger trig;

    public static bool isTrigger;

    public bool trigger
    {
        get
        {
            return isTrigger;
        }
        set
        {
            isTrigger = value;
        }
    }

    public EnemyShoot(bool trig)
    {
        this.trigger = trig;
    }

    void Start()
    {
        this.trigger = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void startAttack()
    {
        fireRate -= Time.deltaTime;

        Vector3 direction = player.position - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

        if (fireRate <= 0)
        {
            fireRate = 1.5f;
            Shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.trigger == true)
        {
            startAttack();
        }
    }

    void Shoot()
    {
        Instantiate(fireball, shootPoint.position, shootPoint.rotation);
    }
}

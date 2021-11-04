using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private Animator amt;

    [SerializeField] private GameObject bossUI;

    public bool isTrigger;
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
    private void Start()
    {
        amt = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            trigger = false;
            amt.SetBool("idle_normal",true);
        }
        else
        {
            trigger = true;
            EnemyShoot enm = new EnemyShoot(trigger);
            bossUI.SetActive(true);
            amt.SetBool("idle_combat", true);
            amt.SetBool("idle_normal", false);
            amt.SetBool("attack_short_001", true);
        }
    }
}

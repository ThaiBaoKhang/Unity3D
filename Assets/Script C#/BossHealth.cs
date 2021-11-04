using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float MaxFill = 1f;

    public float currentFill;

    public static BossHealth singleton;

    Image bar;

    static bool isTakingDmg = false;

    public static Animator bossAmt;

    public GameObject bossUI;

    void Start()
    {
        singleton = this;
        currentFill = MaxFill;
        bossAmt = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTakingDmg)
        {
            
            
        }
        else
        {
            
        }
        isTakingDmg = false;
    }

    public void takeDmg(float dmg)
    {
        bar = GameObject.FindGameObjectWithTag("BossHealthFull").GetComponent<Image>();
        if (currentFill > 0)
        {
            if (dmg >= currentFill)
            {
                isTakingDmg = true;
                Dead();
            }
            else
            {
                isTakingDmg = true;
                currentFill -= dmg;
                bar.fillAmount = currentFill;
            }
        }
    }

    void Dead()
    {
        bossAmt.SetBool("dead", true);
        currentFill = 0;
        bar.fillAmount = currentFill;
        EnemyShoot enm = new EnemyShoot(false);
        bossUI.SetActive(false);
    }
}

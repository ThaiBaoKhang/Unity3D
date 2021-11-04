using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float MaxFill = 1f;

    public float currentFill;

    public static CharacterHealth singleton;

    Image bar;

    public Color dmgColor;

    public Image dmgImage;

    float colorSmoothing = 6f;

    static bool isTakingDmg = false;

    public GameObject healthUI;

    public Animator playerAnimator;

    CharacterController control;

    public Animator BossAnimator;

    public static bool IsDead = false;

    public bool isDeaD
    {
        get
        {
            return IsDead;
        }
        set
        {
            IsDead = value;
        }
    }

    void Start()
    {
        singleton = this;
        currentFill = MaxFill;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        BossAnimator = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTakingDmg)
        {
            dmgImage.color = dmgColor;
        }
        else
        {
            dmgImage.color = Color.Lerp(dmgImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }
        isTakingDmg = false;
    }

    public void takeDmg(float dmg)
    {
        if (currentFill > 0)
        {
            bar = GameObject.FindGameObjectWithTag("PlayerHealthFull").GetComponent<Image>();
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
        currentFill = 0;
        bar.fillAmount = currentFill;
        healthUI.SetActive(false);
        playerAnimator.SetInteger("AniDie", 1);
        control.enabled = false;
        Pistol ps = new Pistol(true);
        EnemyShoot enm = new EnemyShoot(false);
        BossAnimator.SetBool("idle_combat", false);
        BossAnimator.SetBool("idle_normal", true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    // Start is called before the first frame update

    RaycastHit hit;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    int currentAmmo;

    [SerializeField]
    float rateofFire;
    float nextFire = 0;

    [SerializeField]
    float weaponRange;

    Ray ray;

    public Camera cam;

    public float damagetoBoss = 0.1f;

    public static Animator bossAmt;

    private static bool checkDead = false;

    void Start()
    {
        bossAmt = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
    }

    public bool isDeaD
    {
        get
        {
            return checkDead;
        }
        set
        {
            checkDead = value;
        }
    }

    void shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + rateofFire;

            currentAmmo--;

            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out hit, weaponRange))
            {
                if (hit.transform.tag == "Monster")
                {
                    BossHealth bHealth = hit.transform.GetComponent<BossHealth>();
                    bHealth.takeDmg(damagetoBoss);
                    
                }
            }
        }
    }

    public Pistol(bool dea)
    {
        this.isDeaD = dea;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetButton("Fire1") && currentAmmo > 0 && !isDeaD)
        {
            shoot();
        }
    }
}

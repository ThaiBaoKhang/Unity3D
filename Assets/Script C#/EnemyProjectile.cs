using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float damage = 0.1f;

    Rigidbody rb;

    [SerializeField]
    float speed = 800000f;

    public GameObject exploisionPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 fireballAccuracy = new Vector3(Random.Range(0, 0.8f), Random.Range(0, 0.8f), Random.Range(0, 0.8f));
        Vector3 direction = (target.position - transform.position) + fireballAccuracy;
        rb.AddForce(direction * speed * Time.deltaTime);
    }
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            CharacterHealth chrHealth = collision.transform.GetComponent<CharacterHealth>();
            chrHealth.takeDmg(damage);
            GameObject e = Instantiate(exploisionPrefab, transform.position, transform.rotation);
            var ps = GetComponentsInChildren<ParticleSystem>();
            foreach (var p in ps)
            {
                p.Play();
            }
            Destroy(e);
            Destroy(this.gameObject);
        }
        else
        {
            var ps = GetComponentsInChildren<ParticleSystem>();
            foreach (var p in ps)
            {
                p.Play();
            }
            GameObject e = Instantiate(exploisionPrefab, transform.position, transform.rotation);
            Destroy(e, 1f);
            Destroy(this.gameObject,0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

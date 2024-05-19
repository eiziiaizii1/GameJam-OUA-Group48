using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TargetBasicEnemies : MonoBehaviour, IDamagetable
{
    private Rigidbody2D enemyRb2;
    [SerializeField] float heroHitShake = 2f;
    public Slider HealthBar;
    [SerializeField] private GameObject body; 

    [SerializeField] int maxHealth = 100;
    [SerializeField] int health;
    private int animDeadID;

    private Animator anim;

    

    void Awake()
    {
        health = maxHealth;
        enemyRb2 = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        animDeadID = Animator.StringToHash("dead");
    }

    public void BulletDamageBasicEnemies(int takeDamage) 
    {
        health -= takeDamage;
        if ( HealthBar != null)
        {
            HealthBar.value = health;
        }
        
    }

    public void BasicEnemiesDeath()
    {
        if (health <= 0)
        {
            Vector3 moveVector = new Vector3(0f, -0.55f , 0f);

            anim.SetBool(animDeadID, true);
            body.transform.Translate(moveVector);
            StartCoroutine(Death(2f));
            
        }
        
    }

    IEnumerator Death(float deathTime) 
    {
        yield return new  WaitForSeconds(deathTime);
        
        gameObject.SetActive(false);
        Destroy(gameObject, 3f);
    }





   /*private void BrokenParticle()
    {
        ParticleSystem targetBrokenParticle= Instantiate(targetBroken, transform.position, Quaternion.identity);
        Destroy(targetBrokenParticle.gameObject, 2f);

    }*/

}

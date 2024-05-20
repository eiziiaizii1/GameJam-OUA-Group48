using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStorage : MonoBehaviour
{
    private int hearts;
    private int clocks;
    private int maxHealth = 100;
    private int health;
    public  int heroDamageBasicEnemies = 10;
    
    //animator
    private int animDeadID;
    private int animHurtID;
    private Animator anim;
    private bool isDead;

    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject GameOverPanel;
 
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        
        health = maxHealth;     
        //hearts = 50;
        //clocks = 10;
    }
    private void Start()
    {
        AssingHeroAnimatorID();
    }
    public void AssingHeroAnimatorID()
    {
        animDeadID = Animator.StringToHash("dead");
        animHurtID = Animator.StringToHash("hurt");
    }

    public void TakeDamage(int Takedamage)
    {
        health -= Takedamage;      
        healthSlider.value = health;
        SoundManager.Instance.PlayEffectSound(SoundManager.Instance.PlayerHurtSound, 0.15f);
        anim.SetTrigger(animHurtID);
        HeroDeath();
    }
    public void AddHeart()
    {
        health = maxHealth;
        healthSlider.value = health;
        BaseUI.instance.UpdateHearts(hearts);
    }
    public void AddClocks()
    {
        //clocks++;
        //BaseUI.instance.UpdateClocks(clocks);
    }

    public void HeroDeath()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true; // Karakterin öldüðünü iþaretle.
            SoundManager.Instance.PlayEffectSound(SoundManager.Instance.DyingPlayerSound, 0.3f); 
            anim.SetBool(animDeadID, true);

            Invoke("Destroyed", 2.5f);
            
        }
    }
    void Destroyed()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}

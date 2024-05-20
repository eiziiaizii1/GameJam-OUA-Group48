using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioSource
        EffectSource,
        EnvironmentAudioSource,
        EnemyAudioSource,
        BackgroundMusicSource;

    [SerializeField] private AudioClip laserSoundEffect;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip collectibleSound1;
    [SerializeField] private AudioClip collectibleSound2;

    [SerializeField] private AudioClip playerHurtSound;
    [SerializeField] private AudioClip dyingPlayerSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip reloadSound;

    [SerializeField] private AudioClip enemySpawnSound;
    [SerializeField] private AudioClip dyingEnemySound;
    [SerializeField] private AudioClip enemyHurtSound;

    public AudioClip LaserSoundEffect { get => laserSoundEffect; set => laserSoundEffect = value; }
    public AudioClip EnemySpawnSound { get => enemySpawnSound; set => enemySpawnSound = value; }
    public AudioClip GameOverSound { get => gameOverSound; set => gameOverSound = value; }
    public AudioClip PlayerHurtSound { get => playerHurtSound; set => playerHurtSound = value; }
    public AudioClip DyingPlayerSound { get => dyingPlayerSound; set => dyingPlayerSound = value; }
    public AudioClip DyingEnemySound { get => dyingEnemySound; set => dyingEnemySound = value; }
    public AudioClip EnemyHurtSound { get => enemyHurtSound; set => enemyHurtSound = value; }
    public AudioClip JumpSound { get => jumpSound; set => jumpSound = value; }
    public AudioClip CollectibleSound1 { get => collectibleSound1; set => collectibleSound1 = value; }
    public AudioClip CollectibleSound2 { get => collectibleSound2; set => collectibleSound2 = value; }
    public AudioClip ReloadSound { get => reloadSound; set => reloadSound = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //BackgroundMusicSource.Play();
        
    }

    /*
    public void RunSound()
    {
        RunSource.Play();
    }
    public void StopRunSound()
    {
        RunSource.Stop();
    }
    */

    public void PlayBackgroundSound()
    {
        BackgroundMusicSource.Play();
    }
    public void StopBackgroundSound()
    {
        BackgroundMusicSource.Stop();
    }

    public void StopEffectSounds()
    {
        BackgroundMusicSource.Stop();
    }

    public void PlayEffectSound(AudioClip clipToPlay, float effectVolume)
    {
        EffectSource.volume = effectVolume;

        EffectSource.PlayOneShot(clipToPlay);
    }

    public void PlayEnvironmentSound(AudioClip clipToPlay, float effectVolume)
    {
        EffectSource.volume = effectVolume;

        EffectSource.PlayOneShot(clipToPlay);
    }

    public void PlayEnemySound(AudioClip clipToPlay, float effectVolume)
    {
        EffectSource.volume = effectVolume;

        EffectSource.PlayOneShot(clipToPlay);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] HeroMovement heroMovement;
    void Awake()
    {
        // Oyun bilgisayarda çalışıyorsa
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer ||
            Application.platform == RuntimePlatform.LinuxPlayer)
        {
            // Butonları gizle
            gameObject.SetActive(false);
            heroMovement.playingMobile = false;
        }
        // Oyun mobil cihazda çalışıyorsa
        else if (Application.platform == RuntimePlatform.Android ||
                 Application.platform == RuntimePlatform.IPhonePlayer)
        {
            heroMovement.playingMobile = true;
            gameObject.SetActive(true);
        }
    }


}

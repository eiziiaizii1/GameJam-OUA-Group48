using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] HeroMovement heroMovement;
    void Awake()
    {
        // Oyun bilgisayarda �al���yorsa
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer ||
            Application.platform == RuntimePlatform.LinuxPlayer)
        {
            // Butonlar� gizle
            gameObject.SetActive(false);
            heroMovement.playingMobile = false;
        }
        // Oyun mobil cihazda �al���yorsa
        else if (Application.platform == RuntimePlatform.Android ||
                 Application.platform == RuntimePlatform.IPhonePlayer)
        {
            heroMovement.playingMobile = true;
            gameObject.SetActive(true);
        }
    }


}

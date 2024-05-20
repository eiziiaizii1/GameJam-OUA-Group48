using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickable pickObj = collision.gameObject.GetComponent<IPickable>();
        if (pickObj != null)
        {
            SoundManager.Instance.PlayEnvironmentSound(SoundManager.Instance.CollectibleSound1, .2f);
            pickObj.PickItem(this.gameObject.GetComponent<HeroStorage>());
        }
    }
}

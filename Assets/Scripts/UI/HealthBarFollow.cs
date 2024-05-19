using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform targetCharacter;

    void LateUpdate()
    {
        // Health bar'�n pozisyonunu karakterin pozisyonuna e�itle
        if (targetCharacter != null)
        {
            transform.position = targetCharacter.position;
        }

        // Health bar'�n d�n���n� s�f�rla
        transform.localRotation = Quaternion.identity;
    }
}
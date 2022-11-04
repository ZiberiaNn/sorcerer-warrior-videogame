using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public PlayerData playerData;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.CompareTag("Player"))
        {
            SoundManager soundManager = FindObjectOfType<SoundManager>();
            if(soundManager!=null) soundManager.Play("Libro");
            playerData.score++;
            collider.gameObject.GetComponent<PlayerHealthSystem>().UpdateHealth(10,false);
            Destroy(gameObject);
        }
    }
}

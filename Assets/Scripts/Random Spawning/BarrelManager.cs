using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelManager : MonoBehaviour
{
    public GameObject coin;
    public int spawnCoins = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            AudioManager.Instance.Play("BarrelBreak");
            for (int i = 0; i < spawnCoins; i++)
            {
                GameObject coinClone = Instantiate(coin, transform.position, Quaternion.identity);
                coinClone.GetComponent<CoinManager>().RandomDirectionBoost();
            }
        }
    }
    
}

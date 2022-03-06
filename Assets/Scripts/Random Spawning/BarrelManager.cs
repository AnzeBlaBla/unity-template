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
            AudioManager.Instance.Play("BarrelBreak");
            for (int i = 0; i < spawnCoins; i++)
            {
                GameObject coinClone = Instantiate(coin, transform.position, Quaternion.identity);
                coinClone.AddComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 10, ForceMode.Impulse);
            }
            Destroy(this.gameObject);     
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.Play("CoinCollected");
            GameManager.Instance.CollectCoin();
            Destroy(this.gameObject);
        }
    }
}

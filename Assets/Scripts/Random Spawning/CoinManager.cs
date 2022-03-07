using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public float killAfter = 10.0f;
    public bool canBeCollected = true;
    public float explosionForce = 5f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(KillCoin());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && canBeCollected)
        {
            AudioManager.Instance.Play("CoinCollected");
            GameManager.Instance.CollectCoin();
            Destroy(this.gameObject);
        }
    }
    public void RandomDirectionBoost()
    {
        canBeCollected = false;
        var randomDirection = Random.insideUnitSphere;
        // make it point only up
        randomDirection.y = randomDirection.y < 0 ? -randomDirection.y : randomDirection.y;
        rb.AddForce(randomDirection * explosionForce, ForceMode.Impulse);
        //Debug.Log("RandomDirectionBoost");
        StartCoroutine(EnableCollectionAfter(0.3f));
    }

    public IEnumerator EnableCollectionAfter(float after)
    {
        yield return new WaitForSeconds(after);
        canBeCollected = true;
    }
    public IEnumerator KillCoin()
    {
        yield return new WaitForSeconds(killAfter);
        Destroy(this.gameObject);
    }
}

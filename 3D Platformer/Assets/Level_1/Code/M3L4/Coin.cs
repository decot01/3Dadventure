using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {

        CoinsCounter coins = other.GetComponent<CoinsCounter>();

        coins.CollectCoins();

        Destroy(gameObject);
    }
}

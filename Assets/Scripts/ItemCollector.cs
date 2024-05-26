using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int strawberries = 0;

    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private Text StrawberriesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Strawberry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            strawberries++;
            Debug.Log("Strawberries:" +  strawberries);
            StrawberriesText.text = "Strawberries:" + strawberries;
        }    
    }
}

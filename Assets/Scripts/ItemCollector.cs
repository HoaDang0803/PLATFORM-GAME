using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int items = 0;

    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private Text itemText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("item"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            items++;
            Debug.Log("Fruits:" +  items);
            itemText.text = "Fruits:" + items;
        }    
    }
}

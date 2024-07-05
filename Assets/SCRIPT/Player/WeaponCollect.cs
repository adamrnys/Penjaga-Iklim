using UnityEngine;

public class WeaponCollect : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject weaponCollect;

    private void Awake()
    {
        weaponCollect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            gameObject.SetActive(false);
            weaponCollect.SetActive(true);
        }
    }
}

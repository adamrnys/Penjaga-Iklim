using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        //test start
        if (anim == null) Debug.LogError("Animator is not assigned!");
        if (playerMovement == null) Debug.LogError("PlayerMovement is not assigned!");
        if (firePoint == null) Debug.LogError("FirePoint is not assigned!");
        if (fireballs == null || fireballs.Length == 0) Debug.LogError("Fireballs are not assigned or empty!");
        //test end
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    public void OnAttackButtonPressed()
    {
        if (cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //test start
        int fireballIndex = FindFireball();
        if (fireballIndex < 0 || fireballIndex >= fireballs.Length)
        {
            Debug.LogError("No valid fireball found or index out of range!");
            return;
        }

        if (fireballs[fireballIndex] == null)
        {
            Debug.LogError("Fireball at index " + fireballIndex + " is null!");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("FirePoint is null!");
            return;
        }
        //test end
        fireballs[fireballIndex].transform.position = firePoint.position;
        fireballs[fireballIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    [SerializeField] protected float PowerupDuration = 2f;
    [SerializeField] private AudioClip _pickUpSound;
    bool _hit = false;


    void OnTriggerEnter(Collider other)
    {
        if (_hit) return;
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile == null) return;

        AudioHelper.PlayClip2D(_pickUpSound, 1, .1f);
        OnHit();
    }

    protected virtual void OnHit()
    {
        _hit = true;
        StartCoroutine(PowerupSequence());
    }

    void DisableVisuals()
    {
        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }

    protected abstract void Powerup();
    protected abstract void PowerDown();

    IEnumerator PowerupSequence()
    {
        Debug.Log($"{gameObject.name}: PowerupSequence");
        DisableVisuals();
        Powerup();
        yield return new WaitForSeconds(PowerupDuration);
        PowerDown();
        Destroy(gameObject);
    }
}

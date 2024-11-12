using DG.Tweening;
using UniRx; // Для ReactiveCommand
using System.Collections;
using UnityEngine;
using ZombieShooter.InventorySystem.WeaponSystem.Handlers;
using ZombieShooter.InventorySystem.WeaponSystem;
using ZombieShooter.InventorySystem.SO;
using Zenject;
namespace ZombieShooter.WeaponSystem
{
public class ShellEject : MonoBehaviour
{
[Inject] ShellEjectConfig _config;
[Inject] IWeaponHandler weaponHandler;
private Transform _ejectionPoint;
private GameObject ShellPrefab;

private void Start()
{
    _ejectionPoint = transform;
    var handlerComponent = FindObjectOfType<WeaponHandler>();
    if (handlerComponent != null)
    {
        weaponHandler = handlerComponent;
        if (weaponHandler.ActiveWeapon != null)
        {
            SubscribeToWeapon(weaponHandler.ActiveWeapon);
        }

        weaponHandler.OnEquip.Subscribe(weapon => SubscribeToWeapon(weapon));
    }
}

private void SubscribeToWeapon(IWeapon weapon)
{
    if (weaponHandler?.ActiveWeapon != null)
    {
        weaponHandler.ActiveWeapon.OnShoot -= EjectShell;
    }

    if (weapon != null)
    {
        weapon.OnShoot += EjectShell;
    }
}

private void EjectShell()
{
    var shell = Instantiate(ShellPrefab, _ejectionPoint.position, _ejectionPoint.rotation);
    shell.SetActive(true);

    Rigidbody2D shellRb = shell.GetComponent<Rigidbody2D>();
    if (shellRb != null)
    {
        Vector2 shootDirection = (Vector2)_ejectionPoint.up;

        shellRb.velocity = shootDirection * _config.EjectForce;

        shellRb.angularVelocity = 0; 
    }

    StartCoroutine(FadeAndDestroyShell(shell));
}

private IEnumerator FadeAndDestroyShell(GameObject shell)
{
    yield return new WaitForSeconds(_config.LifeTime);

    SpriteRenderer renderer = shell.GetComponent<SpriteRenderer>();
    if (renderer != null)
    {
        renderer.DOFade(0, _config.FadeDuration).OnComplete(() =>
        {
            Destroy(shell);
        });
    }
    else
    {
        Destroy(shell);
    }
}
}
}

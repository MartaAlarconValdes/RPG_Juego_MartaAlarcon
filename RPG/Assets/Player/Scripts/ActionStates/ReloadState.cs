using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : ActionBaseState
{
    float reloadTime = 2f;  // Tiempo para recargar el arma (puedes ajustarlo)
    float reloadTimer = 0f;

    public override void EnterState(ActionStateManager actionStateManager)
    {
        // Cuando el estado de recarga se activa, comienza el temporizador
        reloadTimer = reloadTime;
        actionStateManager.anim.SetTrigger("Reload"); // Si tienes una animación de recarga
    }

    public override void UpdateState(ActionStateManager actionStateManager)
    {
        // Durante la recarga, se cuenta el tiempo
        reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0f)
        {
            // Cuando termina el tiempo de recarga, recargamos el arma
            actionStateManager.WeaponReloaded();  // Recargar el arma
            actionStateManager.SwitchState(actionStateManager.Default); // Volver al estado predeterminado
        }
    }

}

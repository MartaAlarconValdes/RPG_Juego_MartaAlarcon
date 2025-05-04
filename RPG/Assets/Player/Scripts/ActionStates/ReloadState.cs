using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : ActionBaseState
{
    float reloadTime = 2f;  
    float reloadTimer = 0f;

    public override void EnterState(ActionStateManager actions)
    {
        reloadTimer = reloadTime;
        actions.anim.SetTrigger("Reload");
    }

    public override void UpdateState(ActionStateManager actionStateManager)
    {
        reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0f)
        {
            actionStateManager.WeaponReloaded();  
            actionStateManager.SwitchState(actionStateManager.Default); 
        }
    }

}

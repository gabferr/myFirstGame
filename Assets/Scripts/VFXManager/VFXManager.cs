using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFisrtGame.Core.Singleton;
using System.Diagnostics.Contracts;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        VFX_2
    }
    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXByType(VFXType type, Vector3 position)
    {
        foreach (var vfx in vfxSetup) { 
        if(vfx.vfxType == type)
            {
                var item = Instantiate(vfx.prefab);
                item.transform.position = position;
                Destroy(item.gameObject,5f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}

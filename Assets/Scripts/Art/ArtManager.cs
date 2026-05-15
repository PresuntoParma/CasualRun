using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum artType
    {
        TYPE_01,
        TYPE_02,
        BEACH,
        SNOW
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(artType artType)
    {
       return artSetups.Find(i => i.artType == artType);
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.artType artType;
    public GameObject gameObject;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.artType artType)
    {
        var setup = colorSetups.Find(i => i.artType == artType);

        for(int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_BaseColor", setup.colors[i]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.artType artType;
    public List<Color> colors;
}
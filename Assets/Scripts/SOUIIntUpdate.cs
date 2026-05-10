using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soint;
    public TextMeshProUGUI uiTextValue;

    private void Update()
    {
        uiTextValue.text = soint.value.ToString();
    }
}

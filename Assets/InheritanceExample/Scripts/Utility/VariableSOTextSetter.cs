using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariableSOTextSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] string _prefix;
    [SerializeField] string _suffix;
    [SerializeField] FloatSO _floatSO;

    void OnValidate()
    {
        if (_text == null) { _text = GetComponent<TextMeshProUGUI>(); }
    }

    void Update()
    {
        _text.text = _prefix + (_floatSO.value / 1) + _suffix;
    }
}

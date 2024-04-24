using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MyController : MonoBehaviour
{
    public Material MyMaterial;

    [SerializeField]
    private float _mySpeed = 0.5f;

    [SerializeField]
    private float _myTotalTime = 0.0f;

    private void Update()
    {
        if (MyMaterial == null) return;

        // calcul du temps total a passer au shader
        _myTotalTime = _myTotalTime + (_mySpeed * Time.deltaTime);

        // envoi du temps total au shader
        MyMaterial.SetFloat("_TotalTime", _myTotalTime);
    }

}

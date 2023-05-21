using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownController : MonoBehaviour
{
    [SerializeField]
    private Transform _finishPoint;

    [SerializeField] 
    private BoxController _boxController;

    [SerializeField] private MovingController _movingController;

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Rope"))
        {
            
            _boxController.DropDown(_finishPoint.position);
        }
    }

   
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField]
    private LineController _lineController;
    [SerializeField]
    private GameObject _rope;
    [SerializeField] 
    private float _speedDelivery;

    
    private Vector3[] _movePoints  ;
    private Vector3 _nextPosition;
    private int _index = 1;
    private bool _isAllPointsWriteDown = false;
    private bool _isPositionChoice = false;
    private float _time;
   
   

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GetRootetoDelivery();
            ChoicePositionForStart();
           
            StartCoroutine(MoveToFinish());
        }
    }

    private void ChoicePositionForStart()
    {
        if (!_isPositionChoice)
        { 
            _nextPosition = _movePoints[_index];
            _isPositionChoice = true;
        }
    }
    private void GetRootetoDelivery()
    {
        if (!_lineController.GetStateLine() && !_isAllPointsWriteDown)
        {
            _movePoints = new Vector3[]{};
           _movePoints = _lineController.GetArrayPoint().ToArray();
            _isAllPointsWriteDown = true;
        }
    }
    
   public IEnumerator MoveToFinish()
    {
        while (_index < _movePoints.Length)
        {
            _time += Time.deltaTime;
            var distance = Vector3.Distance(transform.position, _nextPosition);
            var travelTime = distance / _speedDelivery;
            var progress = _time / travelTime;
            _rope.transform.position =  Vector3.MoveTowards(transform.position, _nextPosition, _speedDelivery*Time.deltaTime);
            
           /* if (Vector3.Distance(_rope.transform.position, _nextPosition) < 0.2f)
            {
                _index++;
                ChangeNextPosition();
                _time = 0f;
            }*/
           if (_rope.transform.position == _nextPosition)
           {
               _index++;
               ChangeNextPosition();
               _time = 0f;
           }
            
            yield return null;
        }
    }

   private void OnTriggerExit(Collider other)
   {
        if (other.CompareTag("Finish")) 
        {
            Debug.Log("StopAllCoroutines");
            StopAllCoroutines();
        }
   }

   private void ChangeNextPosition()
    {
        if (_index < _movePoints.Length)
        {
            _nextPosition = _movePoints[_index];
        }

    }
}


/*
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField]
    private LineController _lineController;
    [SerializeField]
    private GameObject _rope;
    [SerializeField] 
    private float _speedDelivery;

    private Vector3[] _movePoints  ;
    private Vector3 _currentPosition;
    private Vector3 _nextPosition;
    private int _index = 1;
    private bool _isAllPointsWriteDown = false;
    private bool _isPositionChoice = false;

    private float _time;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

            GetRootetoDelivery();
            ChoicePositionForStart();
        }
        if (_isAllPointsWriteDown)
        {
            MoveToFinish();
        }
    }

    private void ChoicePositionForStart()
    {
        
        if (!_isPositionChoice)
        {
            _currentPosition = _rope.transform.position;
            _nextPosition = _movePoints[_index];
            _isPositionChoice = true;
        }
    }
    private void GetRootetoDelivery()
    {
        if (!_lineController.GetStateLine() && !_isAllPointsWriteDown)
        {
            _movePoints = new Vector3[]{};
           _movePoints = _lineController.GetArrayPoint().ToArray();
            _isAllPointsWriteDown = true;
        }
    }
    
    private void MoveToFinish()
    {
        Debug.Log("MoveToFinish");

         _time += Time.deltaTime;
        var distance = Vector3.Distance(_currentPosition, _nextPosition);
        var travelTime = distance / _speedDelivery;
        var progress = _time / travelTime;
        var newPosition =  Vector3.MoveTowards(_currentPosition, _nextPosition, progress);

        gameObject.transform.position = newPosition;
           
        if (transform.position == _nextPosition)
        {
            Debug.Log("transform.position == _nextPosition");
            _currentPosition = _nextPosition;
            _time = 0f;
        }

        _index++;
        Debug.Log(_index);

        if (_index < _movePoints.Length)
        {
            Debug.Log("_index < _movePoints.Length");

            ChangeNextPosition();
        }
        return;
    }

    private void ChangeNextPosition()
    {
        _nextPosition = _movePoints[_index];
        Debug.Log("ChangeNextPosition");

    }

    
}
*/
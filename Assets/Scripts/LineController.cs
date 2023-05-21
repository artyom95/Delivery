using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] 
    private Transform _firstPosition;
    
    private LineRenderer _lineRenderer;

    [SerializeField] 
    private LayerMask _layer;

    private bool _isLineDraw = false;

    private Vector3 _currentPosition;
    private Vector3 _startPosition;
    private List<Vector3> _movePoints = new ();
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
       _movePoints.Add(_firstPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !_isLineDraw)
        {
            _currentPosition = (Vector3)GetMousePosition();
            if (_currentPosition == _startPosition)
            {
               
                return;
            } 
            Draw();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isLineDraw = true;
        }
       
    }

    public bool GetStateLine()
    {
        if (_isLineDraw)
        {
            return true;
        }

        return false;
    }
    public List<Vector3> GetArrayPoint()
    {
        return _movePoints;
    }
    private void Draw()
    {
        _startPosition = (Vector3)GetMousePosition();
        _movePoints.Add(new Vector3(_currentPosition.x,_currentPosition.y,0f));
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1,
            new Vector3(_currentPosition.x, _currentPosition.y, 0f));
    }
    private Vector3? GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,  out RaycastHit hitInfo, _layer))
        {
           return hitInfo.point;

        } 
        return null;
    }
}

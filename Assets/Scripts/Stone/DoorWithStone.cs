using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithStone : MonoBehaviour
{
    private bool _isOpen;
    private bool _isClose;
    private Transform _cube;
    private Vector3 _currentPos;

    public float massForOpen = 5f;
    public float distance = 4f;

    public void Awake()
    {
        _cube = transform.GetChild(0);
        _currentPos = _cube.localPosition;
    }

    public void Open(float mass)
    {
        if (mass >= massForOpen)
        {
            _isOpen = true;
            _isClose = false;
        }
    }

    public void Close(float mass)
    {
        if (mass >= massForOpen)
        {
            _isClose = true;
            _isOpen = false;
        }
    }

    void Update()
    {
        if (_isOpen == true)
        {
            _cube.localPosition = Vector3.MoveTowards(_cube.localPosition, Vector3.up * distance, Time.deltaTime * 2);
            if (_cube.localPosition.y >= Vector3.up.y * distance)
            {
                _isOpen = false;
            }
        }
        else if (_isClose == true)
        {
            _cube.localPosition = Vector3.MoveTowards(_cube.localPosition, _currentPos, Time.deltaTime * 2);
            if (_cube.localPosition.y <= Vector3.down.y * distance)
            {
                _isClose = false;
            }
        }
        else
        {
            return;
        }
    }
}

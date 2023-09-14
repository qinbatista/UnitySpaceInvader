using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOPoints", menuName = "ScriptableObjects/SOPoints", order = 1)]
public class SOPoints : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] int _currentPoints;
    [SerializeField] int _maxPoints;
    public int CurrentPoints { get => _currentPoints; set => _currentPoints = value; }
    public void AddPoints()
    {
        _currentPoints++;
        _maxPoints = Mathf.Max(_currentPoints, _maxPoints);
    }
    public void ResetPoints()
    {
        _currentPoints = 0;
    }
}

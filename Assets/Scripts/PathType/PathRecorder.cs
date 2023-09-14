using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRecorder : MonoBehaviour
{
    [SerializeField] List<Transform> _path = new List<Transform>();
    public List<Transform> Path { get => _path; }
}

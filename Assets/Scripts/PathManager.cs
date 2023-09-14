using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PathManager : Singleton<PathManager>
{
    // Start is called before the first frame update
    [SerializeField] Transform _group1;
    [SerializeField] Transform _group2;
    [SerializeField] Transform _UFO;
    [SerializeField] PathRecorder _square;
    [SerializeField] PathRecorder _triangular;
    [SerializeField] PathCircularRecorder _circular;
    Coroutine _movementCoroutine;
    public void Start()
    {
        StartCoroutine(PathExecution(_square,_group1));
        StartCoroutine(PathExecution(_triangular,_group2));
        StartCoroutine(PathCircularExecution(_circular,_UFO));
    }

    IEnumerator PathExecution(PathRecorder pathRecorder, Transform _NPC)
    {
        int count = 0;
        List<Transform> _path = pathRecorder.Path;
        float speed = 2;
        while (true)
        {
            if (count < _path.Count)
            {
                _NPC.position = Vector3.MoveTowards(_NPC.position, _path[count].position, speed * Time.deltaTime);
                speed += 4f * Time.deltaTime;
                if (_NPC.position == _path[count].position)
                {
                    count++;
                    speed = 2;
                }
                if (count == _path.Count)
                {
                    count = 0;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator PathCircularExecution(PathCircularRecorder pathCircularRecorder, Transform _NPC)
    {
        Transform origin = pathCircularRecorder.transform;
        float time = 0;
        bool movedToOrigin = false;//smooth transition to origin
        while (true)
        {
            if (!movedToOrigin && _NPC.position != new Vector3(origin.position.x + Mathf.Sin(0) * pathCircularRecorder.Diameter, origin.position.y, origin.position.z + Mathf.Cos(0) * pathCircularRecorder.Diameter))
            {
                _NPC.position = Vector3.MoveTowards(_NPC.position, new Vector3(origin.position.x + Mathf.Sin(0) * pathCircularRecorder.Diameter, origin.position.y, origin.position.z + Mathf.Cos(0) * pathCircularRecorder.Diameter), 10f * Time.deltaTime);
            }
            else if (!movedToOrigin && _NPC.position == new Vector3(origin.position.x + Mathf.Sin(0) * pathCircularRecorder.Diameter, origin.position.y, origin.position.z + Mathf.Cos(0) * pathCircularRecorder.Diameter))
            {
                movedToOrigin = true;
            }
            if (movedToOrigin)
            {
                time += Time.deltaTime;
                _NPC.position = new Vector3(origin.position.x + Mathf.Sin(time) * pathCircularRecorder.Diameter, origin.position.y, origin.position.z + Mathf.Cos(time) * pathCircularRecorder.Diameter);
            }
            yield return new WaitForFixedUpdate();
        }
    }
}

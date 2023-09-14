using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    // Start is called before the first frame update
    RoleAnimation _roleAnimation;
    void Awake()
    {
        _roleAnimation = GetComponent<RoleAnimation>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
        if (hit.collider == null)
        {
            _roleAnimation.SetShottingAnimation(true);
        }
        else
        {
            _roleAnimation.SetShottingAnimation(false);
        }
    }
}

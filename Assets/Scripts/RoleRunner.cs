using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleRunner : MonoBehaviour
{
    // Start is called before the first frame update
    RoleAnimation _roleAnimation;
    Vector3 _origin;
    Rigidbody _rigidbody;
    int _life;
    void Awake()
    {
        _roleAnimation = GetComponent<RoleAnimation>();
        _rigidbody = GetComponent<Rigidbody>();
        _origin = transform.position;
        _life = 5;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * GameManager.Instance.GameLevel);
        _roleAnimation.SetWalkAnimation(true);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _origin;
            GameManager.Instance.ReducedLife();
        }
    }
    public void OnHit()
    {
        _rigidbody.AddForce(new Vector3(0,2,5), ForceMode.Impulse);
        _life--;
        if(_life==0)
        {
            transform.position = _origin;
            GameManager.Instance.IncreaseGameLevel();
        }
    }
}

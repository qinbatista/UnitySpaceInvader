using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleAnimation : MonoBehaviour
{
    Animator _animator;
    //animation hash id
    int _isIdleKey;
    int _isWalkingKey;
    float _walkingSpeed;
    int _shotting;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _isIdleKey = Animator.StringToHash("isIdle");
        _isWalkingKey = Animator.StringToHash("isWalking");
        _walkingSpeed = Animator.StringToHash("walkingSpeed");
        _shotting = Animator.StringToHash("shooting");
    }
    public void SetWalkAnimation(bool isWalking)=>_animator.SetBool(_isWalkingKey, isWalking);
    public void SetIdleAnimation(bool isIdle)=>_animator.SetBool(_isIdleKey, isIdle);
    public void SetShottingAnimation(bool isShotting)=>_animator.SetBool(_shotting, isShotting);
    void OnEnable()
    {
        _animator.speed = Random.Range(0.5f,6f);
    }
}

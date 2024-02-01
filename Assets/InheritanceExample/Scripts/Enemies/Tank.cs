using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] float _movePauseDuration = 1f;
    Coroutine _movePauseCoroutine;
    float _originalMoveSpeed;

    void Start()
    {
        _originalMoveSpeed = MoveSpeed;
    }

    protected override void OnHit()
    {
        PauseMovement();
    }
    void PauseMovement()
    {
        if (_movePauseCoroutine != null)
        {
            StopCoroutine(_movePauseCoroutine);
        }

        _movePauseCoroutine = StartCoroutine(MovePauseCoroutine());
    }

    IEnumerator MovePauseCoroutine()
    {
        MoveSpeed = 0f;
        yield return new WaitForSeconds(_movePauseDuration);
        MoveSpeed = _originalMoveSpeed;
    }
   
}

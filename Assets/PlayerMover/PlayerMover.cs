using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputProvider;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private bool _doDefaultSetting = true;
    [Space(20)]
    [SerializeField] private float _moveSpeed = 50;
    [SerializeField] private Transform _cameraTransfrom;
    
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_cameraTransfrom == null) 
        {
            _cameraTransfrom = Camera.main.transform;
        }

        if (!_doDefaultSetting) return;
        // 抗力
        _rigidbody.drag = 5;
        // X,Z軸の回転を固定
        _rigidbody.constraints = (int)RigidbodyConstraints.FreezeRotationX + RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var inputMoveVector = UnityInputProvider.Instance.MoveVector();

        var cameraForwardRot = Quaternion.Euler(0, _cameraTransfrom.eulerAngles.y, 0);
        var moveVector = cameraForwardRot * inputMoveVector * _moveSpeed;

        _rigidbody.AddForce(moveVector, ForceMode.Acceleration);
        transform.rotation = cameraForwardRot;
    }
}

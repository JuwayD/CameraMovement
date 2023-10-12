using System.Collections;
using System.Collections.Generic;
using CameraMovement;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float max;
    public float min;
    public AnimationCurve Curve;
    public CameraMovementConfigState[] StateConfigList;
    // Start is called before the first frame update
    void Start()
    {
        CameraMovementStateMachine.Instance.Init(StateConfigList);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var temp = Curve.keys[0];
            temp.value = 50;
            Curve.MoveKey(0, temp);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            var temp = Curve.keys[1];
            temp.value = 50;
            Curve.MoveKey(1, temp);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var temp = Curve.keys[0];
            temp.value = 0;
            Curve.MoveKey(0, temp);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            var temp = Curve.keys[1];
            temp.value = 0;
            Curve.MoveKey(1, temp);
        }
        CameraMovementStateMachine.Instance.Tick();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraMovementStateMachine.Instance.Context.RemoveAllConfig();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            CameraMovementStateMachine.Instance.Context.Invoke();
        }

        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     CameraMovementStateMachine.Instance.Context.AddConfigData(EContextMember.ZoomMax, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMax) + 2);
        // }else if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMax, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMax) - 2);
        // }
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMin, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMin) + 2);
        // }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMin, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMin) - 2);
        // }

        max = CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMax);
        min = CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMin);
    }
}

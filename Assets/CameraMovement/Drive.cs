using System.Collections;
using System.Collections.Generic;
using CameraMovement;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float max;
    public float min;
    public CameraMovementConfigState[] StateConfigList;
    // Start is called before the first frame update
    void Start()
    {
        CameraMovementStateMachine.Instance.Init(StateConfigList);
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovementStateMachine.Instance.Tick();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMin, 0);
            CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMax, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMax, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMax) + 2);
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMax, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMax) - 2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMin, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMin) + 2);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CameraMovementStateMachine.Instance.Context.SetContextMember(EContextMember.ZoomMin, CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMin) - 2);
        }

        max = CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMax);
        min = CameraMovementStateMachine.Instance.Context.GetContextMember(EContextMember.ZoomMin);
    }
}

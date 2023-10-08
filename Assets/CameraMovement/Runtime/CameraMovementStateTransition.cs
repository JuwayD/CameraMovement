using System;
using System.Collections.Generic;

namespace CameraMovement
{
    public class CameraMovementStateTransition
    {
        
        #region 生命周期

        public CameraMovementStateTransition(CameraMovementStateBase from, CameraMovementStateBase toState)
        {
            FromState = from;
            ToState = toState;
        }
        #endregion

        #region 条件判断

        private List<Func<CameraMovementContext, bool>> conditions_ = new();

        public bool ConditionMeets(CameraMovementContext context)
        {
            foreach (var condition in conditions_)
            {
                if (condition.Invoke(context) ==  false)
                {
                    return false;
                }
            }
            return true;
        }

        // 通常而言，相机的条件检测只需要在第一次初始化时添加，所以只提供添加条件的接口，另可清空所有条件
        // 作为卸载时使用。不建议动态remove或清空条件，会触发闭包的GC。

        public void AddConditionCheck(Func<CameraMovementContext, bool> condition)
        {
            conditions_.Add(condition);
        }

        public void ClearConditions()
        {
            conditions_.Clear();
        }
        #endregion

        #region 检测部分
        public readonly CameraMovementStateBase FromState;
        public readonly CameraMovementStateBase ToState;

        public event Action<CameraMovementContext> OnTransition;

        public void AddTransitCallBack(Action<CameraMovementContext> callBack)
        {
            OnTransition += callBack;
        }
        
        public virtual void OnTransit(CameraMovementContext context)
        {
            OnTransition?.Invoke(context);
        }
        #endregion

    }
}
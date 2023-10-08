using System.Collections.Generic;
using UnityEngine;

namespace CameraMovement
{
    public class CameraMovementStateMachine
    {
        #region 字段

        public CameraMovementContext Context => context_;
        protected CameraMovementContext context_;
        protected CameraMovementStateBase currentState_;
        protected List<CameraMovementStateTransition> transitionList_;

        #endregion

        #region 生命周期函数

        public void Tick()
        {
            context_.Tick();

            int maxCheckCount = 0;
            for (int i = 0; i < transitionList_.Count; i++)
            {
                if (transitionList_[i].FromState == currentState_ && transitionList_[i].ConditionMeets(context_))
                {
                    Transit(transitionList_[i]);
                    i = 0;//跳转完成后重新检测 保证新状态有通路的情况下立即进行跳转
                    maxCheckCount++;
                    if (maxCheckCount > 7)
                    {
                        Debug.LogError($"状态通路出现循环!");
                        break;
                    }
                }
            }
            
            currentState_.Tick();
        }

        /// <summary>
        /// 流转
        /// </summary>
        public void Transit(CameraMovementStateTransition transition)
        {
            transition.FromState.Exit(transition.ToState);
            transition.OnTransit(context_);
            currentState_ = transition.ToState;
            transition.ToState.Enter(transition.FromState);
        }

        #endregion
        
    }
}
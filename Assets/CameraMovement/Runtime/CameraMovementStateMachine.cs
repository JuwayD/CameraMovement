using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CameraMovement
{
    public class CameraMovementStateMachine
    {
        
        
        #region 字段

        public static CameraMovementStateMachine Instance
        {
            get
            {
                if (instance_ == null)
                {
                    instance_ = new CameraMovementStateMachine();
                    return instance_;
                }

                return instance_;
            }
        }

        private static CameraMovementStateMachine instance_;
        public CameraMovementContext Context => context_;
        protected CameraMovementContext context_ = new CameraMovementContext();
        protected CameraMovementStateBase currentState_;
        protected Dictionary<Type, CameraMovementStateBase> stateDict_ = new Dictionary<Type, CameraMovementStateBase>()
        {
            {typeof(CameraMovementStateFreeLook),new CameraMovementStateFreeLook()},
            {typeof(CameraMovementStateThreeRD),new CameraMovementStateThreeRD()},
        };
        protected List<CameraMovementStateTransition> transitionList_;

        #endregion

        #region 生命周期函数

        public void Init(CameraMovementConfigState[] configs)
        {
            context_.Init();    
            stateDict_[typeof(CameraMovementStateFreeLook)].Init(GameObject.Find("CameraRoot/CM/FreeLook"), configs[1], this);
            stateDict_[typeof(CameraMovementStateThreeRD)].Init(GameObject.Find("CameraRoot/CM/ThreeRD"), configs[0], this);
            transitionList_ = new List<CameraMovementStateTransition>();
            CameraMovementStateTransition temp;
            temp = new CameraMovementStateTransition(typeof(CameraMovementStateFreeLook), typeof(CameraMovementStateThreeRD));
            temp.AddConditionCheck(context => context.GetContextMember(EContextMember.ZoomMax) > 10);
            transitionList_.Add(temp);
            temp = new CameraMovementStateTransition(typeof(CameraMovementStateThreeRD), typeof(CameraMovementStateFreeLook));
            temp.AddConditionCheck(context => context.GetContextMember(EContextMember.ZoomMax) < 10);
            transitionList_.Add(temp);
            currentState_ = stateDict_[typeof(CameraMovementStateFreeLook)];
            currentState_.Enter(null);
        }
        
        public void Tick()
        {
            context_.Tick();

            int maxCheckCount = 0;
            for (int i = 0; i < transitionList_.Count; i++)
            {
                if (stateDict_[transitionList_[i].FromState] == currentState_ && transitionList_[i].ConditionMeets(context_))
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
            context_.ResetEvent();//事件在state中被响应state后清理，保证一帧中所有事件可以被处理
        }

        /// <summary>
        /// 流转
        /// </summary>
        public void Transit(CameraMovementStateTransition transition)
        {
            stateDict_[transition.FromState].Exit(stateDict_[transition.ToState]);
            transition.OnTransit(context_);
            currentState_ = stateDict_[transition.ToState];
            stateDict_[transition.ToState].Enter(stateDict_[transition.FromState]);
        }

        #endregion
        
    }
}
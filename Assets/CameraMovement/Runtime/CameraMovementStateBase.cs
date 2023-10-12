using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace CameraMovement
{
    /// <summary>
    /// 正在运行的模板
    /// </summary>
    public class RuntimeTemplate
    {
        public CameraMovementConfig Config;
        public float CostTime;
    }

    /// <summary>
    /// 运镜状态基类
    /// </summary>
    public abstract class CameraMovementStateBase
    {
        #region 字段

        protected abstract CinemachineVirtualCameraBase VirtualCamera { get;}

        protected readonly Type virtualCameraType_;
        protected readonly Type bodyCompType_;
        protected readonly Type aimCompType_;
        protected readonly Type noiseCompType_;
        protected readonly Type finalizeCompType_;
        protected readonly List<Type> extensionTypeList_;
        protected List<CinemachineExtension> extensionList_ = new List<CinemachineExtension>();
        protected List<ICameraMovementControlField<CinemachineExtension>> controlExtensionList_ = new List<ICameraMovementControlField<CinemachineExtension>>();
        protected CameraMovementStateMachine machine_;
        protected CameraMovementConfigState config_;
        protected Dictionary<int, RuntimeTemplate> runtimeTemplateDict_ = new Dictionary<int, RuntimeTemplate>();

        #endregion

        #region 生命周期函数

        public void Init(GameObject go,CameraMovementConfigState configState, CameraMovementStateMachine machine)
        {
            config_ = configState;
            machine_ = machine;
            OnInit(go, configState, machine);
        }

        /// <summary>
        /// 子类需要在这个里面设置好操控的组件，及部分初始化操作
        /// </summary>
        /// <param name="go"></param>
        /// <param name="configState"></param>
        /// <param name="machine"></param>
        protected abstract void OnInit(GameObject go, CameraMovementConfigState configState, CameraMovementStateMachine machine);

        public void Tick()
        {
            //处理所有事件及其触发的补正
            for (int i = (int)EContextEvent.None + 1; i < machine_.Context.ContextEventBit.Count; i++)
            {
                if (machine_.Context.ContextEventBit.Get(i))
                {
                    processTriggerRecenter((EContextEvent)i, machine_.Context.CameraEventParamDict[(EContextEvent)i]);
                }
            }

            ControlCinemachine();
            //更新所有拓展
            controlCinemachineExtension();
            
            List<int> deleteList = new List<int>();
            foreach (var runtimeTemplate in runtimeTemplateDict_.Values)
            {
                if (runtimeTemplate.CostTime > runtimeTemplate.Config.duration)
                {
                    deleteList.Add(runtimeTemplate.Config.id);
                }
                runtimeTemplate.CostTime += Time.deltaTime;
            }

            foreach (var id in deleteList)
            {
                var config = runtimeTemplateDict_[id];
                OnTemplateRemove(config.Config);
                runtimeTemplateDict_.Remove(id);
            }
        }

        protected abstract void OnTemplateRemove(CameraMovementConfig config);

        /// <summary>
        /// 处理补正
        /// </summary>
        /// <param name="contextEvent"></param>
        /// <param name="paramDict"></param>
        private void processTriggerRecenter(EContextEvent contextEvent, Dictionary<EEventParamType, float> paramDict)
        {
            for (int i = 0; i < config_.ConfigList.Count; i++)
            {
                var config = config_.ConfigList[i];
                if (config.contextEvent == contextEvent && checkCondition(config.Condition))
                {
                    machine_.Context.AddConfigData(config);
                    if (runtimeTemplateDict_.ContainsKey(config.id))
                    {
                        runtimeTemplateDict_[config.id].CostTime = 0;
                        runtimeTemplateDict_[config.id].Config = config;
                    }
                    else
                    {
                        runtimeTemplateDict_.Add(config.id, new RuntimeTemplate(){CostTime = 0, Config = config});
                    }
                    AddConfig(config);
                    for (int j = 0; j < controlExtensionList_.Count; j++)
                    {
                        var extension = extensionList_[i];
                        controlExtensionList_[i].AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority, ref extension, runtimeTemplateDict_);
                    }
                }
            }
        }

        private bool checkCondition(CalculatorItem[] expression)
        {
            return expression == null || expression.Length == 0 ||
                   !Mathf.Approximately(Calculator.Calculate(expression), 0);
        }
        
        protected abstract void AddConfig(CameraMovementConfig config);

        /// <summary>
        /// 控制cinemachine的数据
        /// </summary>
        protected abstract void ControlCinemachine();
        
        /// <summary>
        /// 更新cinemachine拓展
        /// </summary>
        private void controlCinemachineExtension()
        {
            for (int i = 0; i < controlExtensionList_.Count; i++)
            {
                for (int j = 0; j < extensionList_.Count; j++)
                {
                    var controlField = controlExtensionList_[i];
                    var extension = extensionList_[j];
                    if (controlField.AttachControlField == extension.GetType())
                    {
                        controlField.ControlCinemachine(ref extension, runtimeTemplateDict_);
                    }
                }
            }
        }
        
        /// <summary>
        /// 退出当前状态
        /// </summary>
        /// <param name="fromState"></param>
        public void Enter(CameraMovementStateBase fromState)
        {
            VirtualCamera.Priority = 10;
            OnEnter(fromState);
        }

        public abstract void OnEnter(CameraMovementStateBase fromState);

        /// <summary>
        /// 退出当前状态
        /// </summary>
        /// <param name="toState"></param>
        public void Exit(CameraMovementStateBase toState)
        {
            VirtualCamera.Priority = 0;
            OnExit(toState);
        }

        public abstract void OnExit(CameraMovementStateBase toState);

        public void UnInit()
        {
            OnUnInit();
            config_ = null;
            machine_ = null;
            extensionList_.Clear();
        }
        
        public abstract void OnUnInit();
        
        #endregion

    }

}
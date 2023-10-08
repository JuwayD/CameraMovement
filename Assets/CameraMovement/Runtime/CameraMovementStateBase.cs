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

        protected CinemachineVirtualCameraBase virtualCamera_;
        protected CinemachineComponentBase bodyComp_;
        protected CinemachineComponentBase aimComp_;
        protected CinemachineComponentBase noiseComp_;
        protected CinemachineComponentBase finalizeComp_;
        protected List<CinemachineExtension> extensionList_;
        protected ICameraMovementControlField controlVirtualCamera_;
        protected ICameraMovementControlField controlBodyComp_;
        protected ICameraMovementControlField controlAimComp_;
        protected ICameraMovementControlField controlNoiseComp_;
        protected ICameraMovementControlField controlFinalizeComp_;
        protected List<ICameraMovementControlField> controlExtensionList_;
        protected ICameraMovementDataField dataField_;
        protected CameraMovementStateMachine machine_;
        protected CameraMovementConfigState config_;
        protected Dictionary<int, RuntimeTemplate> runtimeTemplateDict_;

        #endregion

        #region 生命周期函数

        public void Tick()
        {
            //处理所有事件及其触发的补正
            for (int i = (int)EContextEvent.None + 1; i < machine_.Context.CameraEventBit.Count; i++)
            {
                if (machine_.Context.CameraEventBit.Get(i))
                {
                    processTriggerRecenter((EContextEvent)i, machine_.Context.CameraEventParamDict[(EContextEvent)i]);
                }
            }

            foreach (var runtimeTemplate in runtimeTemplateDict_.Values)
            {
                runtimeTemplate.CostTime += Time.deltaTime;
            }
            controlCinemachine();
        }

        /// <summary>
        /// 处理补正
        /// </summary>
        /// <param name="contextEvent"></param>
        /// <param name="paramDict"></param>
        private void processTriggerRecenter(EContextEvent contextEvent, Dictionary<EEventParamType, float> paramDict)
        {
            for (int i = 0; i < config_.configList.Count; i++)
            {
                var config = config_.configList[i];
                if (config.contextEvent == contextEvent)
                {
                    machine_.Context.UpdateDataField(config.DataConfigBaseTemplate); 
                    controlVirtualCamera_.AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority);
                    controlBodyComp_.AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority);
                    controlAimComp_.AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority);
                    controlNoiseComp_.AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority);
                    controlFinalizeComp_.AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority);
                    for (int j = 0; j < controlExtensionList_.Count; j++)
                    {
                        controlExtensionList_[i].AddByConfig(config.controlConfigBaseTemplate, config.id, config.priority);
                    }
                }
            }
        }

        /// <summary>
        /// 控制cinemachine的数据
        /// </summary>
        private void controlCinemachine()
        {
            //更新Cinemachine相机
            if (controlVirtualCamera_.GetType() == virtualCamera_.GetType())
            {
                controlVirtualCamera_.ControlCinemachine(virtualCamera_, runtimeTemplateDict_);
            }
            //更新Cinemachine body组件
            if (controlBodyComp_.GetType() == bodyComp_.GetType())
            {
                controlBodyComp_.ControlCinemachine(bodyComp_, runtimeTemplateDict_);
            }
            //更新Cinemachine anim组件
            if (controlAimComp_.GetType() == aimComp_.GetType())
            {
                controlAimComp_.ControlCinemachine(aimComp_, runtimeTemplateDict_);
            }
            //更新Cinemachine noise组件
            if (controlNoiseComp_.GetType() == noiseComp_.GetType())
            {
                controlNoiseComp_.ControlCinemachine(noiseComp_, runtimeTemplateDict_);
            }
            //更新Cinemachine finalize组件
            if (controlFinalizeComp_.GetType() == finalizeComp_.GetType())
            {
                controlFinalizeComp_.ControlCinemachine(finalizeComp_, runtimeTemplateDict_);
            }
            
            //更新所有拓展
            controlCinemachineExtension();
        }
        
        /// <summary>
        /// 更新cinemachine拓展
        /// </summary>
        private void controlCinemachineExtension()
        {
            foreach (var controlField in controlExtensionList_)
            {
                foreach (var extension in extensionList_)
                {
                    if (controlField.AttachControlField == extension.GetType())
                    {
                        controlField.ControlCinemachine(extension, runtimeTemplateDict_);
                    }
                }
            }
        }
        
        /// <summary>
        /// 退出当前状态
        /// </summary>
        /// <param name="toState"></param>
        public void Exit(CameraMovementStateBase toState)
        {
            OnExit(toState);
        }

        public abstract void OnExit(CameraMovementStateBase toState);

        /// <summary>
        /// 退出当前状态
        /// </summary>
        /// <param name="fromState"></param>
        public void Enter(CameraMovementStateBase fromState)
        {
            OnEnter(fromState);
        }

        public abstract void OnEnter(CameraMovementStateBase fromState);

        #endregion

    }

}
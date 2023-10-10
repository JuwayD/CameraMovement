using System.Collections;
using System.Collections.Generic;

namespace CameraMovement
{
    public class CameraMovementContext
    {
        #region 字段

        /// <summary>
        /// 数据区
        /// </summary>
        /// <returns></returns>
        protected ICameraMovementDataField dataField_;

        /// <summary>
        /// 标志哪个相机事件被触发
        /// </summary>
        public BitArray CameraEventBit;

        /// <summary>
        /// 标志哪个相机事件被触发
        /// </summary>
        public Dictionary<EContextEvent, Dictionary<EEventParamType, float>> CameraEventParamDict;

        #endregion

        #region 周期函数

        public void Tick()
        {
            CameraEventBit.SetAll(false);
            CameraEventBit.Set((int)EContextEvent.Tick, true);
        }

        #endregion

        #region 外部函数

        /// <summary>
        /// 更新数据区通过数据区配置
        /// </summary>
        /// <param name="dataConfigBase"></param>
        public void UpdateDataField(CameraMovementDataConfigBase dataConfigBase)
        {
        }

        /// <summary>
        /// 获取上下文成员
        /// </summary>
        /// <param name="member"></param>
        public float GetContextMember(EContextMember member)
        {
            switch (member)
            {
            }

            return 0;
        }
        
        #endregion
        
    }
}
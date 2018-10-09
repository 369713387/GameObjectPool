using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 内存池单元结构
/// </summary>
namespace GameObjectPool
{
    public interface Pool_Unit {
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <returns></returns>
        Pool_UnitState state();

        void setParentList(object parentList);

        /// <summary>
        /// 回收
        /// </summary>
        void restore();
    }

    public enum Pool_Type {
        Enable,
        Disable
    }

    public class Pool_UnitState{
        public Pool_Type type
        {
            get;set;
        }
    }
}

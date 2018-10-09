using System.Collections;
using System.Collections.Generic;
using GameObjectPool;
using UnityEngine;

public abstract class Pooled_BehaviorUnit : BaseBehavior,GameObjectPool.Pool_Unit {

    /// <summary>
    /// 单元状态对象
    /// </summary>
    protected Pool_UnitState m_unitState = new Pool_UnitState();

    /// <summary>
    /// 父列表对象
    /// </summary>
    PoolObjectList<Pooled_BehaviorUnit> m_parentList;

    /// <summary>
    /// 返回一个对象的状态
    /// </summary>
    /// <returns></returns>
    public virtual Pool_UnitState state()
    {
        return m_unitState;
    }

    /// <summary>
    /// 接受父列表对象的设置
    /// </summary>
    public virtual void setParentList(object parentList)
    {
        m_parentList = parentList as PoolObjectList<Pooled_BehaviorUnit>;
    }
    /// <summary>
    /// 回收自己
    /// </summary>
    public virtual void restore()
    {
        if (m_parentList != null)
        {
            m_parentList.restoreObject(this);
        }
    }    
}

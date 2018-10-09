using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObjectPool;

public class Pool_UnitList_Component : PoolObjectList<Pooled_BehaviorUnit> {

    /// <summary>
    /// 对象池组件
    /// </summary>
    protected PoolComponent m_pool;

    /// <summary>
    /// 设置对象池
    /// </summary>
    /// <param name="pool"></param>
    public void setPool(PoolComponent pool)
    {
        m_pool = pool;
    }

    protected override Pooled_BehaviorUnit createNewObject<UT>()
    {
        GameObject result_go = null;
        if (m_template != null && m_template is GameObject)
        {
            result_go = GameObject.Instantiate((GameObject)m_template);
        }
        else
        {
            result_go = new GameObject();
            result_go.name = typeof(UT).Name;
        }
        result_go.name = result_go.name + "_" + m_createdNum;
        UT component = result_go.GetComponent<UT>();
        if (component == null)
        {
            component = result_go.AddComponent<UT>();
        }
        component.DoInit();
        return component;
    }

    protected override void OnChangePool(Pooled_BehaviorUnit obj)
    {
        if (m_pool != null)
        {
            m_pool.OnChangePool(obj);
        }
    }

}

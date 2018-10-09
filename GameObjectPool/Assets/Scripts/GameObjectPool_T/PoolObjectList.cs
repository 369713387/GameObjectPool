using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObjectPool;

public abstract class PoolObjectList<T> where T:class,Pool_Unit{

    protected object m_template;
    protected List<T> m_DisAbleList;
    protected List<T> m_EnAbleList;
    protected int m_createdNum = 0;

    public PoolObjectList()
    {
        m_DisAbleList = new List<T>();
        m_EnAbleList = new List<T>();
    }
    /// <summary>
    /// 获取一个闲置的对象，如果不存在则创建一个新的
    /// </summary>
    /// <typeparam name="UT"></typeparam>
    /// <returns></returns>
    public virtual T GetOneObject<UT>() where UT : T
    {
        T obj;
        if (m_DisAbleList.Count > 0)
        {
            obj = m_DisAbleList[0];
            m_DisAbleList.RemoveAt(0);
        }
        else
        {
            obj = createNewObject<UT>();
            obj.setParentList(this);
            m_createdNum++;
        }
        m_EnAbleList.Add(obj);
        obj.state().type = Pool_Type.Enable;
        OnChangePool(obj);
        return obj; 
    }
    /// <summary>
    /// 回收某个对象
    /// </summary>
    /// <param name="obj"></param>
    public virtual void restoreObject(T obj)
    {
        if(obj != null && obj.state().type == Pool_Type.Enable)
        {
            m_EnAbleList.Remove(obj);
            m_DisAbleList.Add(obj);
            obj.state().type = Pool_Type.Disable;
            OnChangePool(obj);
        }
    }
    /// <summary>
    /// 设置模板
    /// </summary>
    /// <param name="template"></param>
    public void setTemplate(object template)
    {
        m_template = template;
    }

    protected abstract void OnChangePool(T obj);
    protected abstract T createNewObject<UT>() where UT : T;
}

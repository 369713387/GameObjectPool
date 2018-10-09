using GameObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class PoolBase<ObjectType,ObjectList> : BaseBehavior 
    where ObjectType:class,Pool_Unit 
    where ObjectList : PoolObjectList<ObjectType>,new()
{
    /// <summary>
    /// 缓存池中按类型存放各自分类列表
    /// </summary>
    private Dictionary<Type, ObjectList> m_poolTale = new Dictionary<Type, ObjectList>();

    protected override void OnInitFirst()
    {
        
    }
    protected override void OnInitSecond()
    {
        
    }

    protected override void OnUpdate()
    {
        
    }

    /// <summary>
    /// 获取一个空闲的单元
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetObject<T>() where T : class, ObjectType
    {
        ObjectList ls = getList<T>();
        return ls.GetOneObject<T>() as T;
    }
    /// <summary>
    ///在缓冲池中获取指定单元类型的列表，
    /// 如果该单元类型不存在，则立刻创建。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ObjectList getList<T>() where T : ObjectType
    {
        var t = typeof(T);
        ObjectList ls = null;
        m_poolTale.TryGetValue(t, out ls);
        if (ls == null)
        {
            ls = createNewObjectList<T>();
            m_poolTale.Add(t, ls);
        }
        return ls;
    }

    protected abstract ObjectList createNewObjectList<UT>() where UT : ObjectType;
}

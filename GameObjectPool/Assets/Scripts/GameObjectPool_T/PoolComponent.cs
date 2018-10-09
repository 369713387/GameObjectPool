using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObjectPool;

public class PoolComponent : PoolBase<Pooled_BehaviorUnit, Pool_UnitList_Component>{

    [SerializeField]
    [Tooltip("显示父节点")]
    protected Transform m_EnAble;
    [SerializeField]
    [Tooltip("隐藏父节点")]
    protected Transform m_DisAble;

    protected override void OnInitFirst()
    {
        if (m_EnAble == null)
        {
            m_EnAble = ComponentUtil.Create(m_transform, "enable");
        }
        if (m_DisAble == null)
        {
            m_DisAble = ComponentUtil.Create(m_transform, "disable");
            m_DisAble.gameObject.SetActive(false);
        }
    }

    public void OnChangePool(Pooled_BehaviorUnit unit)
    {
        if (unit != null)
        {
            var type = unit.state().type;
            if (type == Pool_Type.Disable)
            {
                unit.m_transform.SetParent(m_DisAble);
            }
            else if (type == Pool_Type.Enable)
            {
                unit.m_transform.SetParent(m_EnAble);
            }
        }
    }

    protected override Pool_UnitList_Component createNewObjectList<UT>()
    {
        Pool_UnitList_Component ls = new Pool_UnitList_Component();
        ls.setPool(this);
        return ls;
    }
}

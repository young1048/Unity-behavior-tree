﻿using BTreeFrame;

namespace Battle.Logic.AI.BTree
{
    public class HasTargetCondition : BTreeNodePrecondition<MyInputData>
    {
        public override bool ExternalCondition(MyInputData _input)
        {
            var troop = _input.troop;
            if (troop.targetKey != 0)
            {
                if (_input.battleData.mAllTroopDic.ContainsKey(troop.targetKey))
                {
                    var target = _input.battleData.mAllTroopDic[troop.targetKey];
                    if (target.count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

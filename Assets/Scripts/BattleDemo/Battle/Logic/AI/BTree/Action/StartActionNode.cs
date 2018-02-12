﻿using BTreeFrame;

namespace Battle.Logic.AI.BTree
{
    public class StartActionNode : BTreeNodeAction<MyInputData, MyOutputData>
    {
        public StartActionNode(BTreeNode<MyInputData, MyOutputData> _parentNode)
            : base(_parentNode)
        {

        }

        protected override BTreeRunningStatus _DoExecute(MyInputData _input, ref MyOutputData _output)
        {
            var troop = _input.troop;
            var outTroop = _output.troop;

            if (troop.count == 0)
            {
                outTroop.state = (int)TroopAnimState.Die;
                return BTreeRunningStatus.Executing;
            }
            if (troop.inPrepose)
            {
                if (troop.preTime > 0)
                {
                    outTroop.preTime = troop.preTime - 1;
                }
                else
                {
                    outTroop.inPrepose = false;
                }
                outTroop.state = (int)TroopAnimState.Idle;
                return BTreeRunningStatus.Executing;
            }
            if (troop.norAtkCD > 0)
            {
                outTroop.norAtkCD = troop.norAtkCD - 1;
                outTroop.state = (int)TroopAnimState.Idle;
                return BTreeRunningStatus.Executing;
            }
            outTroop.state = (int)TroopAnimState.Idle;
            return BTreeRunningStatus.Finish;
        }
    }
}

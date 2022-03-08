using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.Utils.Data
{
    public class PlayerData : Table<PlayerData, PlayerData.PlayerDataInstance>
    {
        public override void OnCreate()
        {
            fileName = "PlayerData";
        }

        public class PlayerDataInstance : DataInstance
        {
            public int Hp;
            public int Damage;
        }
    }

}
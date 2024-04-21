using Artifacts.Core;
using Artifacts.Interfaces;
using Buffs.Interfaces;
using UnityEngine;
using Weapons.Core;

namespace Artifacts
{
    public class TestArtifact : Artifact, IEffect, IStat
    {
        public int GetProcChance()
        {
            return 0;
        }

        public IBuff CreateBuff()
        {
            Debug.Log("working");
            return null;
        }

        public void ApplyStats(Weapon weapon)
        {
            weapon.Stats.Damage += 20;
        }
    }
}
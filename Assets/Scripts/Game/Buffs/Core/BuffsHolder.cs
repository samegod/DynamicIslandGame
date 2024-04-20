using System.Collections.Generic;
using Buffs.Interfaces;
using Enemies.Core;
using Sirenix.Utilities;
using UnityEngine;

namespace Buffs.Core
{
    public class BuffsHolder : MonoBehaviour
    {
        private Enemy _thisEnemy;
        private List<IEffectBuff> _currentBuffs = new List<IEffectBuff>();

        private void Awake()
        {
            _thisEnemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            foreach (var buff in _currentBuffs)
            {
                buff.Update();
            }
        }

        public void AddBuff(IEffectBuff newBuff)
        {
            newBuff.InitEnemy(_thisEnemy);
            newBuff.Start();
            _currentBuffs.Add(newBuff);
        }

        public void AddBuff(List<IEffectBuff> newBuff)
        {
            if (newBuff.IsNullOrEmpty())
                return;

            Debug.Log("addbuff");
            foreach (var buff in newBuff)
            {
                AddBuff(buff);
            }
        }
    }
}

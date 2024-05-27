using System.Collections.Generic;
using Additions.Extensions;
using Effects.Visuals;
using Entities.Interfaces;
using UnityEngine;

namespace Effects
{
    public class LightningBolts : Effect
    {
        private int _currentJump;
        private readonly float _range;
        private LightningEffectVisuals _currentVisuals;

        private RaycastHit[] _targets = new RaycastHit[5];
        
        private const int MaxTargetsCount = 5;
        private const float JumpChance = 1f;
        
        public LightningBolts(EffectTypeId typeId, IEffectable target, float value, EffectVisuals visualsPrefab, int currentJump, float range) : base(typeId, target, value, visualsPrefab)
        {
            _currentJump = currentJump;
            _range = range;
        }
        
        public override void Activate()
        {
            if (_currentJump >= MaxTargetsCount)
            {
                Deactivate();
                return;
            }
            
            float proc = Random.Range(0, 1f);

            if (proc > JumpChance)
                return;
            
            if (_currentJump == 0)
            {
                _currentVisuals = CreateVisuals() as LightningEffectVisuals;
                if (!_currentVisuals)
                    return;
                
                _currentVisuals.transform.position = Target.GetPosition();
                
                NextJump();
            }
            else
            {
                NextJump();
            }

            _currentJump++;
        }

        private void DealDamage()
        {
            if (Target is IHittable hittable)
            {
                hittable.TakeDamage(Value);
            }
        }
        
        private void Deactivate()
        {
            _currentVisuals.Disable();
        }

        private void NextJump()
        {
            List<IEffectable> sortedTargets = new List<IEffectable>();
            int count = Physics.SphereCastNonAlloc(Target.GetPosition(), _range, Vector3.up, _targets);

            for (var i = 0; i < count; i++)
            {
                var temp = _targets[i].transform.GetComponent<IEffectable>();
                if (temp != null)
                {
                    sortedTargets.Add(temp);
                }
            }

            sortedTargets.Remove(Target);

            Debug.Log("2   " );
            Target = sortedTargets.GetRandomElement();
            Debug.Log(Target);
            _currentVisuals.Activate(Target.GetTransform(), () =>
            {
                DealDamage();
                Activate();
            });
        }
    }
}
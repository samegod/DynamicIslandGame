using Enemies.Combat;
using Entities.Interfaces;
using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class CombatState : EnemyState
    {
        private EnemyCombatController _combatController;
        private IHittable _target;
        
        public CombatState(EnemyCombatController combatController, IHittable target)
        {
            _combatController = combatController;
            _target = target;
        }

        public override void Start()
        {
            _combatController.StartCombat(_target);
        }

        public override void Update() { }

        public override void Stop()
        {
            _combatController.StopCombat();
        }
    }
}
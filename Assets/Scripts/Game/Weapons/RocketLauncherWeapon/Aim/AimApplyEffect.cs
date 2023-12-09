using Additions.Effects;
using DG.Tweening;
using UnityEngine;

namespace Weapons.RocketLauncherWeapon.Aim
{
    public class AimApplyEffect : Effect
    {
        [SerializeField] private float animTime;
        [SerializeField] private Vector2 finalScale;
        [SerializeField] private int rotates;

        protected override void EffectLogic()
        {
            Sequence = DOTween.Sequence();
            Sequence.Append(transform.DOScale(finalScale, animTime).SetEase(Ease.OutBack));

            Sequence rotateSequence = DOTween.Sequence();
            
            for (int i = 0; i < rotates; i++)
            {
                rotateSequence.Append(transform.DORotateAround(animTime / rotates / 2f).SetEase(Ease.Linear));
            }

            Sequence.Join(rotateSequence);
        }
    }
}

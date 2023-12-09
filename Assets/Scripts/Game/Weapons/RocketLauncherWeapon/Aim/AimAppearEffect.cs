using Additions.Effects;
using DG.Tweening;
using UnityEngine;

namespace Weapons.RocketLauncherWeapon.Aim
{
    public class AimAppearEffect : Effect
    {
        [SerializeField] private float appearTime;
        [SerializeField] private Vector2 finalScale;
        [SerializeField] private int rotates;

        protected override void EffectLogic()
        {
            Sequence = DOTween.Sequence();
            Sequence.Append(transform.DOScale(finalScale, appearTime).SetEase(Ease.OutBack));

            Sequence rotateSequence = DOTween.Sequence();
            
            for (int i = 0; i < rotates; i++)
            {
                rotateSequence.Append(transform.DORotateAround(appearTime / rotates / 2f).SetEase(Ease.Linear));
            }

            Sequence.Join(rotateSequence);
        }
    }
}

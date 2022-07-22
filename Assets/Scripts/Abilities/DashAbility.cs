using System.Collections;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class DashAbility : Ability
    {
        [SerializeField]
        private GameObject dashEffect;

        [SerializeField] private float dashEffectTime;
        private float dashCurrentTime;
        private bool canDash = true;
        public float dashCooldown;
        private float cooldown;
        private Color color;
        private IEnumerator CoolDownFunction;
        private IEnumerator DashFunction;
        private Color basicColor;
        public static bool isDash=false; // flag for anim dash
        public override void Activate(GameObject player)
        {
            if (canDash && dashEffect != null)
            {
                isDash = true;
                canDash = false;
                DashFunction = DashEffect(player);
                StartCoroutine(DashFunction);
                Material wheelColor = player.transform.Find("playerModel").Find("thething").Find("leg_deform.001").Find("leg_deform.005").Find("leg_deform.006").Find("Wheel").Find("wheel_low").GetComponent<MeshRenderer>().material;
                basicColor = wheelColor.color;
                CoolDownFunction = Cooldown(wheelColor);
                StartCoroutine(CoolDownFunction);
            }
        }

        private IEnumerator DashEffect(GameObject player)
        {
            dashEffect.SetActive(true);
            dashCurrentTime = 0;
            player.GetComponent<Rigidbody>().AddForce(player.transform.forward * 100f, ForceMode.Impulse);
            while (true)
            {
                dashCurrentTime += Time.deltaTime;
                if (dashCurrentTime >= dashEffectTime)
                {
                    dashEffect.SetActive(false);
                    StopCoroutine(DashFunction);
                }

                yield return null;
            }
        }
        private IEnumerator Cooldown(Material wheelColor)
        {
            float changeColor;
            cooldown = 0;
            while (true)
            {
                cooldown += Time.deltaTime;
                changeColor = cooldown / dashCooldown;
                color = Color.Lerp(basicColor.gamma, new Color(191f, 191f, 191f).gamma, changeColor).gamma;
                wheelColor.SetColor("_EmissionColor", color.gamma);
                if (cooldown >= dashCooldown)
                {
                    canDash = true;
                    StopCoroutine(CoolDownFunction);
                }
                yield return null;
            }
        }
    }
}
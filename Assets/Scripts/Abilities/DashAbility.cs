using System.Collections;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class DashAbility : Ability
    {
        private bool canDash = true;
        public float dashCooldown;
        private float cooldown;
        private Color color;
        private IEnumerator CoolDownFunction;
        private Color basicColor;
        public override void Activate(GameObject player)
        {
            if (canDash)
            {
                canDash = false;
                player.GetComponent<Rigidbody>().AddForce(player.transform.forward * 100f, ForceMode.Impulse);
                Material wheelColor = player.transform.GetChild(0).Find("wheel_low").GetComponent<MeshRenderer>().material;
                basicColor = wheelColor.color;
                CoolDownFunction = Cooldown(wheelColor);
                StartCoroutine(CoolDownFunction);
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
                Debug.Log(color);
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
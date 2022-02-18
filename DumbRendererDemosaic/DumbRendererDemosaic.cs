using System.Linq;
using BepInEx;
using BepInEx.Logging;
using DemosaicCommon;
using UnityEngine;

namespace DumbRendererDemosaic
{
    /// <summary>
    /// Scans all renderers for materials that could be mozaics and removes the materials
    /// </summary>
    [BepInPlugin("manlymarco.DumbRendererDemosaic", "Dumb Renderer Demosaic", Metadata.Version)]
    internal class DumbRendererDemosaic : BaseUnityPlugin
    {
        public static readonly string[] MozaicNames = { "MankoMosa", "YSTちんほ (1)", "TNTN (1)" };

        private void Update()
        {
            foreach (var renderer in FindObjectsOfType<Renderer>().Where(x => MozaicNames.Any(name => x.name.Contains(name))))
            {
                Logger.Log(LogLevel.Info, $"Removing mozaic material from renderer {renderer.name}");
                //renderer.material = null;
                renderer.enabled = false;
                renderer.gameObject.SetActive(false);
            }
        }
    }
}

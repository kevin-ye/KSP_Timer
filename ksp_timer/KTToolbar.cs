using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ksp_timer
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class KTToolbar: MonoBehaviour
    {
        private ApplicationLauncherButton button;

        private void Awake()
        {
            GameEvents.onGUIApplicationLauncherReady.Add(this.onGUIApplicationLauncherReady);
            GameEvents.onGUIApplicationLauncherDestroyed.Add(this.onGUIApplicationLauncherDestroyed);
            Logger.log("toolbar awake");
        }

        private void onGUIApplicationLauncherDestroyed()
        {
            if (button != null)
            {
                ApplicationLauncher.Instance.RemoveModApplication(this.button);
                button = null;
            }
        }

        private void onGUIApplicationLauncherReady()
        {
            try
            {
                if (ApplicationLauncher.Ready)
                {
                    button = ApplicationLauncher.Instance.AddModApplication(
                        () => ksp_timer.instance.Visible = true,
                        () => ksp_timer.instance.Visible = false,
                        null, null, null, null,
                        ApplicationLauncher.AppScenes.ALWAYS,
                        GameDatabase.Instance.GetTexture("KSP_Timer/Resource/toolbarButton", false)
                        );
                    Logger.log("Button created");
                }
            }
            catch
            {
                Logger.exception("Failed to create button");
            }
        }

        private void OnDestroy()
        {
            GameEvents.onGUIApplicationLauncherReady.Remove(onGUIApplicationLauncherReady);
            if (button != null)
            {
                ApplicationLauncher.Instance.RemoveModApplication(button);
            }
            Logger.log("toolbar OnDestroy");
        }
    }
}

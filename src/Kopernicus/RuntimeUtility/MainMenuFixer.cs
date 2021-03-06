/**
 * Kopernicus Planetary System Modifier
 * ------------------------------------------------------------- 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301  USA
 * 
 * This library is intended to be used as a plugin for Kerbal Space Program
 * which is copyright 2011-2017 Squad. Your usage of Kerbal Space Program
 * itself is governed by the terms of its EULA, not the license above.
 * 
 * https://kerbalspaceprogram.com
 */
 
using System;
using System.Linq;
using Kopernicus.OnDemand;
using UnityEngine;

namespace Kopernicus
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class MainMenuFixer : MonoBehaviour
    {
        void Awake()
        {
            if (Templates.kopernicusMainMenu)
            {
                // Get the MainMenu-Logic
                MainMenu main = FindObjectOfType<MainMenu>();
                if (main == null)
                {
                    Debug.LogError("[Kopernicus] No main menu object!");
                    return;
                }
                MainMenuEnvLogic logic = main.envLogic;

                // Set it to Space, because the Mun-Area won't work with sth else than Mun
                if (logic.areas.Length < 2)
                {
                    Debug.LogError("[Kopernicus] Not enough scenes");
                    return;
                }

                logic.areas[0].SetActive(false);
                logic.areas[1].SetActive(true);
            }
        }

        public const Single kerbinRotationPeriod = 21600f;

        // Update the menu body
        void Start()
        {
            if (Templates.kopernicusMainMenu)
            {
                // Select a random body?
                if (Templates.randomMainMenuBodies.Any())
                {
                    Templates.menuBody =
                        Templates.randomMainMenuBodies[new System.Random().Next(0, Templates.randomMainMenuBodies.Count)];
                }

                // Grab the main body
                CelestialBody planetCB = PSystemManager.Instance.localBodies.Find(b => b.transform.name == Templates.menuBody);
                if (planetCB == null)
                {
                    planetCB = PSystemManager.Instance.localBodies.Find(b => b.isHomeWorld);
                }
                if (planetCB == null)
                {
                    Debug.LogError("[Kopernicus] Could not find homeworld!");
                    return;
                }

                // Load Textures
                OnDemandStorage.EnableBody(Templates.menuBody);

                // Get the MainMenu-Logic
                MainMenu main = FindObjectOfType<MainMenu>();
                if (main == null)
                {
                    Debug.LogError("[Kopernicus] No main menu object!");
                    return;
                }
                MainMenuEnvLogic logic = main.envLogic;

                // Set it to Space, because the Mun-Area won't work with sth else than Mun
                if (logic.areas.Length < 2)
                {
                    Debug.LogError("[Kopernicus] Not enough bodies");
                    return;
                }

                // Get our active Space
                GameObject space = logic.areas[1];

                // Deactivate Kerbins Transform
                Transform kerbin = space.transform.Find("Kerbin");
                if (kerbin == null)
                {
                    Debug.LogError("[Kopernicus] No Kerbin transform!");
                    return;
                }
                kerbin.gameObject.SetActive(false);

                // Deactivate Muns Transform
                Transform munPivot = space.transform.Find("MunPivot");
                if (munPivot == null)
                {
                    Debug.LogError("[Kopernicus] No MunPivot transform!");
                    return;
                }
                munPivot.gameObject.SetActive(false);

                // Activate the textures
                ScaledSpaceOnDemand od = planetCB.scaledBody.GetComponentInChildren<ScaledSpaceOnDemand>();
                if (od != null)
                {
                    od.Start();
                    od.LoadTextures();
                }

                // Clone the scaledVersion and attach it to the Scene
                GameObject menuPlanet = Instantiate(Utility
                    .FindBody(PSystemManager.Instance.systemPrefab.rootBody, planetCB.transform.name).scaledVersion);
                menuPlanet.transform.parent = space.transform;
                menuPlanet.name = planetCB.transform.name;
                    
                // Destroy stuff
                DestroyImmediate(menuPlanet.GetComponent<ScaledSpaceFader>());
                DestroyImmediate(menuPlanet.GetComponent<SphereCollider>());
                DestroyImmediate(menuPlanet.GetComponentInChildren<AtmosphereFromGround>());
                DestroyImmediate(menuPlanet.GetComponent<MaterialSetDirection>());

                // That sounds funny
                Rotato planetRotato = menuPlanet.AddComponent<Rotato>();
                Rotato planetRefRotato = kerbin.GetComponent<Rotato>();
                planetRotato.speed = planetRefRotato.speed * ((Single)planetCB.rotationPeriod / kerbinRotationPeriod);

                // Scale the body
                menuPlanet.transform.localScale = kerbin.localScale;
                menuPlanet.transform.localPosition = kerbin.localPosition;
                menuPlanet.transform.position = kerbin.position;

                // And set it to layer 0
                menuPlanet.layer = 0;
                
                Events.OnRuntimeUtilityUpdateMenu.Fire();
            }
        }
    }
}

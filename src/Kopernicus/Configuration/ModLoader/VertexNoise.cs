﻿/**
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

namespace Kopernicus
{
    namespace Configuration
    {
        namespace ModLoader
        {
            [RequireConfigType(ConfigType.Node)]
            public class VertexNoise : ModLoader<PQSMod_VertexNoise>
            {
                // falloff
                [ParserTarget("falloff")]
                public NumericParser<Single> falloff
                {
                    get { return mod.falloff; }
                    set { mod.falloff = value; }
                }

                // mesaVsPlainsBias
                [ParserTarget("mesaVsPlainsBias")]
                public NumericParser<Single> mesaVsPlainsBias
                {
                    get { return mod.mesaVsPlainsBias; }
                    set { mod.mesaVsPlainsBias = value; }
                }

                // noiseDeformity
                [ParserTarget("noiseDeformity")]
                public NumericParser<Single> noiseDeformity
                {
                    get { return mod.noiseDeformity; }
                    set { mod.noiseDeformity = value; }
                }

                // noisePasses
                [ParserTarget("noisePasses")]
                public NumericParser<Int32> noisePasses
                {
                    get { return mod.noisePasses; }
                    set { mod.noisePasses = value; }
                }

                // plainSmoothness
                [ParserTarget("plainSmoothness")]
                public NumericParser<Single> plainSmoothness
                {
                    get { return mod.plainSmoothness; }
                    set { mod.plainSmoothness = value; }
                }

                // plainsVsMountainSmoothness
                [ParserTarget("plainsVsMountainSmoothness")]
                public NumericParser<Single> plainsVsMountainSmoothness
                {
                    get { return mod.plainsVsMountainSmoothness; }
                    set { mod.plainsVsMountainSmoothness = value; }
                }

                // plainsVsMountainThreshold
                [ParserTarget("plainsVsMountainThreshold")]
                public NumericParser<Single> plainsVsMountainThreshold
                {
                    get { return mod.plainsVsMountainThreshold; }
                    set { mod.plainsVsMountainThreshold = value; }
                }

                // seed
                [ParserTarget("seed")]
                public NumericParser<Int32> seed
                {
                    get { return mod.seed; }
                    set { mod.seed = value; }
                }

                // smoothness
                [ParserTarget("smoothness")]
                public NumericParser<Single> smoothness
                {
                    get { return mod.smoothness; }
                    set { mod.smoothness = value; }
                }
            }
        }
    }
}


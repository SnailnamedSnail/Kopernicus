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
            public class FlattenArea : ModLoader<PQSMod_FlattenArea>
            {
                // DEBUG_showColors
                [ParserTarget("DEBUG_showColors")]
                public NumericParser<Boolean> DEBUG_showColors
                {
                    get { return mod.DEBUG_showColors; }
                    set { mod.DEBUG_showColors = value; }
                }

                // flattenTo
                [ParserTarget("flattenTo")]
                public NumericParser<Double> flattenTo
                {
                    get { return mod.flattenTo; }
                    set { mod.flattenTo = value; }
                }

                // innerRadius
                [ParserTarget("innerRadius")]
                public NumericParser<Double> innerRadius
                {
                    get { return mod.innerRadius; }
                    set { mod.innerRadius = value; }
                }

                // outerRadius
                [ParserTarget("outerRadius")]
                public NumericParser<Double> outerRadius
                {
                    get { return mod.outerRadius; }
                    set { mod.outerRadius = value; }
                }

                // position
                [ParserTarget("position")]
                public Vector3Parser position
                {
                    get { return mod.position; }
                    set { mod.position = value; }
                }

                // position v2
                [ParserTarget("Position")]
                public PositionParser Position
                {
                    set { mod.position = value; }
                }

                // smoothEnd
                [ParserTarget("smoothEnd")]
                public NumericParser<Double> smoothEnd
                {
                    get { return mod.smoothEnd; }
                    set { mod.smoothEnd = value; }
                }

                // smoothStart
                [ParserTarget("smoothStart")]
                public NumericParser<Double> smoothStart
                {
                    get { return mod.smoothStart; }
                    set { mod.smoothStart = value; }
                }
            }
        }
    }
}


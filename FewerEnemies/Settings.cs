/*using Mutagen.Bethesda.WPF.Reflection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FewerEnemies
{
    internal class Settings
    {
    }
}
*/
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace FewerEnemies
{
    /// <summary>
    /// Contains user-modifiable settings used by the patcher process.
    /// </summary>
    internal class Settings
    {
        [MaintainOrder]
        [Tooltip("The Chance None to use against all NPC leveled list entries")]
        public byte ChanceNone = 25;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public List<string> NameBlacklist;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public byte GetChanceNone()
        {
            return ChanceNone;
        }

        /// <summary>
        /// Apply user settings to the given Leveled NPC list entry.
        /// </summary>
        /// <param name="npc">A copy of an entry in an NPC leveled-list.</param>
        /// <param name="changes">Returns the number of modified values.</param>
        /// <returns>LeveledNpcEntry</returns>
        public LeveledNpc ApplyTo(LeveledNpc npc, out int changes, byte chanceNone)
        {
            changes = 0;
            //if (npc.Data == null) // return early if this entry doesn't have valid data
                //return npc;
            /*if (!npc.ChanceNone.Equals(Level))
            {
                npc.Data.Level = Level;
                ++changes;
            }*/
            //don't need this error check for the chancenone?

            npc.ChanceNone = chanceNone;
            ++changes;
            return npc;
        }
        /// <summary>
        /// Apply user settings to all entries in the given Leveled NPC list.
        /// </summary>
        /// <param name="list">A copy of a NPC leveled-list record.</param>
        /// <param name="changes">Returns the number of modified values.</param>
        /// <returns>LeveledNpc</returns>
    }
}
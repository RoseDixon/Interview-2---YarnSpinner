using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Yarn.Unity
{

    [HelpURL("https://yarnspinner.dev/docs/unity/components/yarn-programs/")]
    public class YarnProject : ScriptableObject
    {

        [SerializeField]
        [HideInInspector]
        public byte[] compiledYarnProgram;

        [SerializeField]
        [HideInInspector]
        public Localization baseLocalization;

        [SerializeField]
        [HideInInspector]
        public List<Localization> localizations = new List<Localization>();

        [SerializeField]
        [HideInInspector]
        public LineMetadata lineMetadata;

        /// <summary>
        /// The names of assemblies that <see cref="ActionManager"/> should look
        /// for commands and functions in when this project is loaded into a
        /// <see cref="DialogueRunner"/>.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        public List<string> searchAssembliesForActions = new List<string>();

        public Localization GetLocalization(string localeCode)
        {

            // If localeCode is null, we use the base localization.
            if (localeCode == null)
            {
                return baseLocalization;
            }

            foreach (var loc in localizations)
            {
                if (loc.LocaleCode == localeCode)
                {
                    return loc;
                }
            }

            // We didn't find a localization. Fall back to the Base
            // localization.
            return baseLocalization;
        }

        Program cachedProgram = null;

        /// <summary>
        /// Deserializes a compiled Yarn program from the stored bytes in
        /// this object.
        /// </summary>
        public Program GetProgram()
        {
            // TODO: Check if compiledYarnProgram has been updated, and re-set cachedProgram if it has.
            if (cachedProgram == null)
            {
                cachedProgram = Program.Parser.ParseFrom(compiledYarnProgram);
            }
            return cachedProgram;
        }
    }
}

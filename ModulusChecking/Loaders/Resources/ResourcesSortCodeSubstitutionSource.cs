using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ModulusChecking.Loaders.Resources
{
    public class ResourcesSortCodeSubstitutionSource : ISortCodeSubstitutionSource
    {
        private Dictionary<string, string> _sortCodeSubstitutionSource;

        private void SetupDictionary()
        {
            if (_sortCodeSubstitutionSource != null) return;
            _sortCodeSubstitutionSource = new Dictionary<string, string>();
            var rows = Properties.Resources.scsubtab.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
            foreach (var items in rows.Select(row => row.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Where(items => items.Length == 2))
            {
                _sortCodeSubstitutionSource.Add(items[0], items[1]);
            }
        }

        public string GetSubstituteSortCode(string original)
        {
            if (_sortCodeSubstitutionSource == null)
            {
                SetupDictionary();
            }
            string sub;
            Debug.Assert(_sortCodeSubstitutionSource != null, "_sortCodeSubstitutionSource != null");
            return _sortCodeSubstitutionSource.TryGetValue(original, out sub) ? sub : original;
        }
    }
}

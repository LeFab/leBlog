using System;
using System.Collections;
using System.Collections.Generic;

namespace leBlog.MarkupParser.Content
{
    internal class Document : IEnumerable<Fragment>
    {
        private readonly List<Fragment> _fragments = new List<Fragment>();

        public void Append(Fragment fragment)
        {
            _fragments.Add(fragment);
        }

        #region IEnumerable
        
        public IEnumerator<Fragment> GetEnumerator()
        {
            return _fragments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        #endregion

        public override string ToString()
        {
            return string.Format("Document consisting of {0} fragments.", _fragments.Count);
        }
    }
}

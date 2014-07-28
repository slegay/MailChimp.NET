using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using ServiceStack.Text;
using ServiceStack.Text.Common;
using ServiceStack.Text.Json;

namespace MailChimp.Lists
{
    [DataContract]
    public struct MemberInfoMergeData
    {
        private Dictionary<string, string> _mergeData;
        private List<Grouping> _groupings;

        public MemberInfoMergeData(string json) {

            var data = JsonObject.Parse(json);
            _groupings = data.Get<List<Grouping>>("GROUPINGS");
            _mergeData = data.ToDictionary();

            if (_mergeData.ContainsKey("GROUPINGS"))
                _mergeData.Remove("GROUPINGS");
        }

        public Dictionary<string, string> MergeData {
            get { return _mergeData; }
        }

        public List<Grouping> Groupings {
            get { return _groupings; }
        }
         
        public override string ToString()
        {
            var dict = new Dictionary<string, object>();

            return MergeData.ToJson(); // TODO: provide deserialization
        }

    }
}

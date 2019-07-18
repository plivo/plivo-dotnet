using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Plivo.Resource.Conference {
    public class ConferenceMemberActionResponse : DeleteResponse<Conference> {
        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>The member identifier.</value>

        //public List<string> MemberId { get; set; }

        public string MemberId { get; set; }
    


        //public void set_MemberId(string value) {
        //    if (!value.Contains(",")) {
        //        this.MemberId = new List<string> { value };
        //    } else {
        //        string clean_string = string.Concat(value.ToCharArray().Select((x, i) => char.IsNumber(x) || x == ',' ? x.ToString() : ""));
        //        List<string> MemberIdList = new List<string>();
        //        foreach (string Member in clean_string.Split(',')) MemberIdList.Add(Member.Trim());
        //        this.MemberId = MemberIdList;
        //    }
        //    Debug.WriteLine("Debugging!");
        //    Debug.WriteLine(this.MemberId);
        //}

        //private List<string> memberId;

        //public string MemberId {
        //    get {
        //        Debug.WriteLine(this.memberId.ToString());
        //        return this.memberId.ToString();
        //    }

        //    set {
        //        if (!value.Contains(",")) {
        //            this.memberId = new List<string> {value};
        //        }
        //        else {
        //            string clean_string = string.Concat(value.ToCharArray().Select(
        //                (x, i) => char.IsNumber(x) || x== ',' ? x.ToString() : ""));
        //            this.memberId = new List<string>(clean_string.Split(','));
        //        }
        //    }
        //}
    }
}
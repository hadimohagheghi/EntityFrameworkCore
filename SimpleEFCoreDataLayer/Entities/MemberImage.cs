using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEFCoreDataLayer.Entities
{
    public class MemberImage:BaseEntity<int>
    {
        //باید یک طرف کلید خارجی قرار بگیرد
        //فقط
        public int MemberId { get; set; }  //Foreign Key for Relation between Member and MemberImage
        public byte[] Image { get; set; }


        public Member Member { get; set; }  //Navigation Property
    }
}

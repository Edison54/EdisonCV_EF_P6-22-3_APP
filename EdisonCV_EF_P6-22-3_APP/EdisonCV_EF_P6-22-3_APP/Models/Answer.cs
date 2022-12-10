using System;
using System.Collections.Generic;
//using Newtonsoft.Json;
//using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdisonCV_EF_P6_22_3_APP.Models
{
    public partial class Answer
    {



      //  public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentype = "Content-Type";





        public Answer()
        {
          
        }

        public long AnswerId { get; set; }
        public int UserId { get; set; }
        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Answer1 { get; set; } = null!;
        public bool? SetAsCorrect { get; set; }
        public bool? IsStrike { get; set; }

        public virtual Ask Ask { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Like> Likes { get; set; }
    }
}

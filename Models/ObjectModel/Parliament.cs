﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ObjectModel
{ 
    public class CommonsSession 
    { 
        public int CommonsSessionID { get; set; } 
        
        [Required]        
        public int Legislature { get; set; } 
        
        [Required]        
        public int Session { get; set; } 
      
        [Required]        
        public DateTime Opening { get; set; } 

        public DateTime Ending { get; set; }

        public int SeatCount { get; set; }

        public bool Dissolved { get; set; }

        public bool BillRez { get; set; }

        public virtual ICollection<CommonsGroup> Composition { get; set; }

        public virtual ICollection<Legislation> Bills { get; set; } 
    } 

    public class CommonsGroup
    {
        public int CommonsGroupID { get; set; }      

        public string Name { get; set; }

        public int Side { get; set; }                // 1 = Government, 2 = OO, 3 = Third Party Oppositions

        public virtual CommonsSession CurrentSession { get; set; }

        public virtual ICollection<Party> Parties { get; set; }

        public virtual ICollection<Message> Thread { get; set; }
    }
    
    public class Senate 
    { 
        public int SenateID { get; set; } 

        public int LiberalSenators { get; set; } 

        public int TorySenators { get; set; } 

        public int Independents { get; set; } 

        public int SeatCount { get; set; } 
    } 
}
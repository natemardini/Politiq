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

        public virtual ICollection<Legislation> Bills { get; set; } 
    } 

    public class Side
    {
        public int SideID { get; set; }      // 1 = Government, 2 = OO, 3 = Third Party Oppositions

        public string Name { get; set; }

        public ICollection<Party> PartiesComposed { get; set; }
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
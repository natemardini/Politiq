﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ObjectModel
{ 
    public class LegislativeSession 
    { 
        public int LegislativeSessionID { get; set; } 
        
        [Required]        
        public int Legislature { get; set; } [Required]        
        public int Session { get; set; } [Required]        
        public DateTime Opening { get; set; } 
        public DateTime Ending { get; set; } 
        public bool Dissolved { get; set; } 
        public ICollection<Legislation> Bills { get; set; } 
    } 

    public class Commons 
    { 
        public int CommonsID { get; set; } 
        public int SeatCount { get; set; } 
        public virtual ICollection<Party> Government { get; set; } 
        public virtual ICollection<Party> OfficialOpposition { get; set; } 
        public virtual ICollection<Party> Opposition { get; set; } 
        public DateTime Opened { get; set; } 
        public DateTime Ended { get; set; } 
    } 
    
    public class Senate 
    { 
        public int SenateID { get; set; } 
        public int LiberalSenators { get; set; } 
        public int TorySenators { get; set; } 
        public int Independents { get; set; } 
        public int SeatCount { get; set; } 
    } 
    public class Party 
    { 
        public int PartyID { get; set; } 
        public string ShortName { get; set; } 
        public string Abbrev { get; set; } 
        public string Name { get; set; } 
        public int Seats { get; set; } 
        public virtual ICollection<Member> Members { get; set; } 
    } 
}
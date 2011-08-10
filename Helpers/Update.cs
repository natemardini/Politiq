using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politiq.Models;
using Politiq.Models.ObjectModel;

namespace Politiq.Helpers
{
    //public class Maintainance
    //{
    //    DAL db = new DAL();
    //    DateTime now = DateTime.Now;

    //    Commons currentParliament;
    //    bool isMajority;

    //    // The stages are: (0) Draft stage, (1) First Reading, (2) Second Reading, (3) Committee, (4) Third Reading, (5) Senate, (6) Royal Assent, (99) Defeated.

    //    public void MoveBills()
    //    {
    //        currentParliament = db.Commons.OrderByDescending(s => s.Opened).FirstOrDefault();
    //        isMajority = currentParliament.Government.Sum(m => m.Seats) > (int)(currentParliament.SeatCount / 2);

    //        var currentBills = db.LegislativeSessions.OrderByDescending(s => s.Ending).FirstOrDefault().Bills;

    //        // Move bills from first reading to second reading automatically after 12 hours

    //        foreach (var bill in currentBills.Where(s => s.Stage.Reading == 1 & (now - s.Stage.LastMovement).Hours >= 20))
    //        {
    //            bill.Stage.Reading = 2;
    //            bill.Stage.LastMovement = now;
    //        }

    //        foreach (var bill in currentBills.Where(s => s.Stage.Reading == 2 & (now - s.Stage.LastMovement).Days >= 3))
    //        {
    //            this.NextReading(bill);                
    //        }

    //        foreach (var bill in currentBills.Where(s => s.Stage.Reading == 3 & (now - s.Stage.LastMovement).Days >= 5))
    //        {
    //            if (this.HouseLeadersMotion(bill))
    //            {
    //                this.NextReading(bill);
    //            }
    //        }

    //        foreach (var bill in currentBills.Where(s => s.Stage.Reading == 4 & (now - s.Stage.LastMovement).Days >= 3))
    //        {
    //            if (this.HouseLeadersMotion(bill))
    //            {
    //                this.NextReading(bill);
    //            }
    //        }

    //        foreach (var bill in currentBills.Where(s => s.Stage.Reading == 5 & (now - s.Stage.LastMovement).Hours >= 12))
    //        {
    //            this.SenateVote(bill);
    //        }

    //        db.SaveChanges();
    //    }

    //    public bool HouseLeadersMotion(Legislation bill)
    //    {
    //        var activeMembers = db.Members.Where(a => (now - a.LastActivity).Days < 7);

    //        var HouseLeaders = activeMembers.Where(m => m.Roles.Any(r => r.RoleLevel == 4 | r.RoleLevel == 5));
								 
    //        if (isMajority)
    //        {
    //            if (bill.BillType == 1)
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                var govHouseLeaders = HouseLeaders.Intersect(currentParliament.Government.SelectMany(p => p.Members));

    //                if (bill.Stage.VotesFor.Intersect(govHouseLeaders).Any())
    //                {
    //                    return true;
    //                }
    //                else
    //                {
    //                    return false;
    //                } 
    //            }
    //        }
    //        else
    //        {
    //           int threshold = 0;
 
    //            foreach (var party in db.Parties)
    //            {
    //                if (HouseLeaders.Intersect(party.Members).Intersect(bill.Stage.VotesFor).Any()) 
    //                {
    //                    threshold += party.Seats;
    //                }
    //            }

    //            if (threshold > (int)(currentParliament.SeatCount / 2))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //    }

    //    private void NextReading(Legislation bill)
    //    {
    //        var result = this.TabulateVote(bill.Stage);

    //        if (result.ElementAt(0) > result.ElementAt(1))
    //        {
    //            this.RecordResult(bill, result);
    //            bill.Stage.Reading += 1;
    //        }
    //        else if (result.ElementAt(0) < result.ElementAt(1))
    //        {
    //            this.RecordResult(bill, result);
    //            bill.Stage.Reading = 99;
    //        }
    //    }

    //    public IList<int> TabulateVote(Stage stage)
    //    {
    //        var parliament = db.Commons.OrderByDescending(p => p.Opened).FirstOrDefault();
    //        int yeas = 0;
    //        int nays = 0;
    //        int absents = 0;

    //        foreach (var party in db.Parties)
    //        {
    //            int partyseats = party.Seats;
    //            // 5 members out of a total of 10 voted for and 100 Seats = 5/10 * 100
    //            int partyyeas = stage.VotesFor.Where(m => m.Party == party).Count();
    //            int partynays = stage.VotesAgainst.Where(m => m.Party == party).Count();
    //            int partyabsent = stage.Abstentions.Where(m => m.Party == party).Count();
    //            int playervotes = partyyeas + partynays + partyabsent;

    //            yeas += (int)(((partyyeas / playervotes) * partyseats));
    //            nays += (int)(((partynays / playervotes) * partyseats));
    //            absents += (int)(((partyabsent / playervotes) * partyseats));
    //        }

    //        IList<int> voteResult = new List<int>();
    //        voteResult.Insert(0, yeas);
    //        voteResult.Insert(1, nays);
    //        voteResult.Insert(2, absents);

    //        return voteResult;
    //    }

    //    private void RecordResult(Legislation bill, IList<int> result)
    //    {
    //        // Enter this stage's result in Hansard
    //        bill.Hansard.Add(new VoteHistory
    //        {
    //            AtStage = bill.Stage,
    //            MPs_For = bill.Stage.VotesFor,
    //            MPs_Against = bill.Stage.VotesAgainst,
    //            Yeas = result.ElementAt(0),
    //            Nays = result.ElementAt(1),
    //            Abstains = result.ElementAt(2)
    //        });
			
    //        // Reset vote count for next stage
    //        bill.Stage.VotesFor = null;
    //        bill.Stage.VotesAgainst = null;
    //        bill.Stage.Abstentions = null;
    //        bill.Stage.LastMovement = now;
    //    }

    //    public IList<int> SenateVote(Legislation bill)
    //    {
    //        Random random = new Random();

    //        if (random.Next(1, 100) > 10)
    //        {
    //            var senate = db.Senate.OrderByDescending(d => d.SenateID).FirstOrDefault();
    //            IList<int> swingvotes = new List<int>();   // 0 - Liberal-to-Tory swing , 1 - Tory-to-Liberal swing

    //            if (bill.BillType == 1)
    //            {
    //                int absence = random.Next(0, 31);
    //                int senatepresence = senate.SeatCount - absence;
    //                int swing = random.Next(2, 12);
    //                int yesvote = senatepresence - swing;
    //                int novote = (senatepresence - yesvote) + swing;
    //                int abstain = random.Next(0, (absence));

    //                bill.Hansard.Add(new VoteHistory
    //                {
    //                    AtStage = bill.Stage,
    //                    MPs_For = null,
    //                    MPs_Against = null,
    //                    Yeas = yesvote,
    //                    Nays = novote,
    //                    Abstains = abstain
    //                });

    //                // Reset vote count for next stage
    //                bill.Stage.VotesFor = null;
    //                bill.Stage.VotesAgainst = null;
    //                bill.Stage.Abstentions = null;
    //                bill.Stage.LastMovement = now;
    //                if (yesvote > novote)
    //                {
    //                    bill.Stage.Reading += 1;
    //                }
    //                else
    //                {
    //                    bill.Stage.Reading = 99;
    //                }

    //                swingvotes.Insert(3, swing);
    //                return swingvotes;
    //            }
    //            else
    //            {
    //                if (bill.Sponsor.Party.Abbrev == "CPC")                         // TODO: Replace with PartyID
    //                {
    //                    int absence = random.Next(1, 50);
    //                    int senatepresence = senate.SeatCount - absence;
    //                    int torytogritswing = random.Next(0, (int)(senate.TorySenators / 4));
    //                    int grittotoryswing = random.Next(2, (int)(senate.LiberalSenators / 2));

    //                    int yesvote = senate.TorySenators * (int)((senatepresence + random.Next(2, 50)) / senate.SeatCount) + grittotoryswing - torytogritswing;
    //                    int novote = senate.LiberalSenators * (int)((senatepresence + random.Next(1, 25)) / senate.SeatCount) + torytogritswing - grittotoryswing;
    //                    int absentees = (senatepresence - (yesvote + novote)) * (int)(random.Next(0, senate.SeatCount) / senate.SeatCount);

    //                    bill.Hansard.Add(new VoteHistory
    //                    {
    //                        AtStage = bill.Stage,
    //                        MPs_For = null,
    //                        MPs_Against = null,
    //                        Yeas = yesvote,
    //                        Nays = novote,
    //                        Abstains = absentees
    //                    });

    //                    // Reset vote count for next stage
    //                    bill.Stage.VotesFor = null;
    //                    bill.Stage.VotesAgainst = null;
    //                    bill.Stage.Abstentions = null;
    //                    bill.Stage.LastMovement = now;

    //                    if (yesvote > novote)
    //                    {
    //                        bill.Stage.Reading += 1;
    //                    }
    //                    else
    //                    {
    //                        bill.Stage.Reading = 99;
    //                    }

    //                    swingvotes.Insert(0, grittotoryswing);
    //                    swingvotes.Insert(1, torytogritswing);
    //                    return swingvotes;
    //                }
    //                else if (bill.Sponsor.Party.Abbrev == "LPC")
    //                {
    //                    int absence = random.Next(1, 50);
    //                    int senatepresence = senate.SeatCount - absence;
    //                    int torytogritswing = random.Next(2, (int)(senate.TorySenators / 2));
    //                    int grittotoryswing = random.Next(0, (int)(senate.LiberalSenators / 4));

    //                    int yesvote = senate.LiberalSenators * (int)((senatepresence + random.Next(2, 50)) / senate.SeatCount) - grittotoryswing + torytogritswing;
    //                    int novote = senate.TorySenators * (int)((senatepresence + random.Next(1, 25)) / senate.SeatCount) - torytogritswing + grittotoryswing;
    //                    int absentees = (senatepresence - (yesvote + novote)) * (int)(random.Next(0, senate.SeatCount) / senate.SeatCount);

    //                    bill.Hansard.Add(new VoteHistory
    //                    {
    //                        AtStage = bill.Stage,
    //                        MPs_For = null,
    //                        MPs_Against = null,
    //                        Yeas = yesvote,
    //                        Nays = novote,
    //                        Abstains = absentees
    //                    });

    //                    // Reset vote count for next stage
    //                    bill.Stage.VotesFor = null;
    //                    bill.Stage.VotesAgainst = null;
    //                    bill.Stage.Abstentions = null;
    //                    bill.Stage.LastMovement = now;

    //                    if (yesvote > novote)
    //                    {
    //                        bill.Stage.Reading += 1;
    //                    }
    //                    else
    //                    {
    //                        bill.Stage.Reading = 99;
    //                    }

    //                    swingvotes.Insert(0, grittotoryswing);
    //                    swingvotes.Insert(1, torytogritswing);
    //                    return swingvotes;
    //                }
    //                else
    //                {
    //                    if (random.Next(1, 100) > 25)
    //                    {
    //                        int absence = random.Next(1, 65);
    //                        int senatepresence = senate.SeatCount - absence;
    //                        int torytogritswing = random.Next(0, (int)(senate.TorySenators / 3));
    //                        int grittotoryswing = random.Next(0, (int)(senate.LiberalSenators / 3));

    //                        int libvote = (int)(senate.LiberalSenators * ((senatepresence + random.Next(0, 65)) / senate.SeatCount)) - grittotoryswing + torytogritswing;
    //                        int toryvote = (int)(senate.TorySenators * ((senatepresence + random.Next(0, 65)) / senate.SeatCount)) - torytogritswing + grittotoryswing;

    //                        int novote; 
    //                        int yesvote;
    //                        if (random.Next(1, 100) > 50)
    //                        {
    //                            yesvote = libvote;
    //                            novote = toryvote;
    //                        }
    //                        else
    //                        {
    //                            yesvote = toryvote;
    //                            novote = libvote;
    //                        }

    //                        int absentees = (int)((senatepresence - (yesvote + novote)) * (random.Next(0, senate.SeatCount) / senate.SeatCount));

    //                        bill.Hansard.Add(new VoteHistory
    //                        {
    //                            AtStage = bill.Stage,
    //                            MPs_For = null,
    //                            MPs_Against = null,
    //                            Yeas = yesvote,
    //                            Nays = novote,
    //                            Abstains = absentees
    //                        });

    //                        // Reset vote count for next stage
    //                        bill.Stage.VotesFor = null;
    //                        bill.Stage.VotesAgainst = null;
    //                        bill.Stage.Abstentions = null;
    //                        bill.Stage.LastMovement = now;

    //                        if (yesvote > novote)
    //                        {
    //                            bill.Stage.Reading += 1;
    //                        }
    //                        else
    //                        {
    //                            bill.Stage.Reading = 99;
    //                        }

    //                        swingvotes.Insert(0, grittotoryswing);
    //                        swingvotes.Insert(1, torytogritswing);
    //                        return swingvotes; 
    //                    }
    //                    return null;
    //                }
    //            } 
    //        }
    //        return null;
    //    }

    //    public void Report()
    //    {
    //        var update = new Politiq.Models.Update
    //        {
    //             UpdateTime = DateTime.Now,
    //             Response = "User-defined Success"
    //        };
    //        db.Updates.Add(update);
    //        db.SaveChanges();		
    //    }
		
    //}
}
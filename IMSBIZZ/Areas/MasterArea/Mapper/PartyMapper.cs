using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class PartyMapper
    {
        public static Party Attach(PartyViewModel partyviewmodel)
        {
            Party party = new Party();

            party.PartyId = partyviewmodel.PartyId;
            party.PartyName = partyviewmodel.PartyName;
            party.PartyAddress = partyviewmodel.PartyAddress;
            party.PartyType = partyviewmodel.PartyType;
            party.CompanyId = partyviewmodel.CompanyId;
            party.BranchId = partyviewmodel.BranchId;
            party.ContactNo = partyviewmodel.ContactNo;
            party.GSTINNo = partyviewmodel.GSTINNo;
            party.Status = partyviewmodel.Status;
            party.CreatedBy = partyviewmodel.CreatedBy;
            party.CreatedOn = partyviewmodel.CreatedOn;
            party.UpdatedBy = partyviewmodel.UpdatedBy;
            party.UpdatedOn = partyviewmodel.UpdatedOn;
            party.StateId = partyviewmodel.StateId;

            return party;
        }
        public static PartyViewModel Detach(Party party)
        {
            PartyViewModel partyviewmodel = new PartyViewModel();

            partyviewmodel.PartyId = party.PartyId;
            partyviewmodel.PartyName = party.PartyName;
            partyviewmodel.PartyAddress = party.PartyAddress;
            partyviewmodel.PartyType = party.PartyType;
            partyviewmodel.CompanyId = party.CompanyId;
            partyviewmodel.BranchId = party.BranchId;
            partyviewmodel.ContactNo = party.ContactNo;
            partyviewmodel.GSTINNo = party.GSTINNo;
            partyviewmodel.Status = party.Status;
            partyviewmodel.CreatedBy = party.CreatedBy;
            partyviewmodel.CreatedOn = party.CreatedOn;
            partyviewmodel.UpdatedBy = party.UpdatedBy;
            partyviewmodel.UpdatedOn = party.UpdatedOn;
            partyviewmodel.StateId = party.StateId;

            return partyviewmodel;
        }
    }
}
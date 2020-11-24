using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJAutos.Models
{
    public class QouteViewModel
    {
        public string CarId { get; set; }
        public int id { get; set; }
        public string QouteId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateBooking { get; set; }
        public int IsDone { get; set; }
        public Decimal TotalUpper { get; set; }
        public Decimal TotalLower { get; set; }

        public List<string> CarIds { get; set; } = new List<string>();

        #region Options
        public bool Maintance { get; set; }
        public bool RepairCheckUp { get; set; }
        public bool TyreChange { get; set; }
        public bool ClutchCheckup { get; set; }
        public bool EngineCheckup { get; set; }
        public bool BreakCheckup { get; set; }
        public bool SuspensionCheckup { get; set; }
        public bool FullFluidChange { get; set; }
        public string Notes { get; set; }

        public int IsNotes { get; set; }

        #endregion


        public void CalculateTotal(Decimal ModelMultiplier,Decimal MakeMultiplier) {

            TotalUpper = GetOrderTotal() * ModelMultiplier * MakeMultiplier ;
        }// populate total 

        public Decimal GetOrderTotal() {
            Decimal ot = 0;

            if (Maintance) { ot += 5000; }
            if (RepairCheckUp ) { ot += 8000; }
            if (TyreChange) { ot += 3000; }
            if (ClutchCheckup ) { ot += 2000; }
            if (EngineCheckup ) { ot += 1000; }
            if (BreakCheckup ) { ot += 800; }
            if (SuspensionCheckup  ) { ot += 2000; }
            if (FullFluidChange ) { ot += 2000; }
            
            if (IsNotes == 1 ) { ot += 100; }

            return ot;
        }

        public SelectList ToSelectList() {

            SelectList sl = new SelectList(this.CarIds.ToArray());
            
            return sl;
        }

        public static List<QouteViewModel> ToQouteViewModel(List<QouteDB> dbqoutes) {
            var viewQoutes = new List<QouteViewModel>();
            foreach (var newQoute in dbqoutes)
            {
                viewQoutes.Add( new QouteViewModel()
                {  

                    CarId = newQoute.CarId,
                    QouteId = newQoute.QouteId,
                    DateBooking = newQoute.DateBooking.GetValueOrDefault(),
                    IsDone = newQoute.IsDone.GetValueOrDefault(),
                    TotalUpper = newQoute.TotalUpper.GetValueOrDefault(),
                    TotalLower = newQoute.TotalLower.GetValueOrDefault(),
                    Maintance = (newQoute.Maintanance == 1),
                    RepairCheckUp = newQoute.RepairCheckup == 1,
                    TyreChange = newQoute.TyreChange == 1,
                    ClutchCheckup = newQoute.ClutchCheckup == 1,
                    EngineCheckup = newQoute.EngineCheckup == 1,
                    BreakCheckup = newQoute.BreakCheckup == 1,
                    SuspensionCheckup = newQoute.SuspensionCheckup == 1,
                    FullFluidChange = newQoute.FullFluidChange == 1,
                    Notes = newQoute.CarId,

                });
            }
            return viewQoutes;
        }


    }
}
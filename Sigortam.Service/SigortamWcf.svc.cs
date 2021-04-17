using Sigortam.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sigortam.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SigortamWcf" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SigortamWcf.svc or SigortamWcf.svc.cs at the Solution Explorer and start debugging.
    public class SigortamWcf : ISigortamWcf
    {
        public List<OfferModel> TeklifHesaplama(string plate ,string Tckn,string stRuhsatSeriKodu,string stRuhsatSeriNo)
        {
            List<OfferModel> offerList = new List<OfferModel>();
            var rand = new Random();
            try
            {
                offerList.Add(new OfferModel() {ConpanyLogo="",ConpanyName="A",Desc="A Fiması",Plate=plate, Price=1000+ rand.Next(100) });
                offerList.Add(new OfferModel() {ConpanyLogo="",ConpanyName="B",Desc="B Fiması",Plate=plate, Price=1000+ rand.Next(55) });
                offerList.Add(new OfferModel() {ConpanyLogo="",ConpanyName="C",Desc="C Fiması",Plate=plate, Price=1000+ rand.Next(60) });

                return offerList;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

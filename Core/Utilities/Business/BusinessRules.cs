using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Bu kısıma parametre olarak IResult tipinde istedğimiz kadar değerler ekleyebiliriz.
        //Run metoduna verdiğimiz parametreleri foreach ile tek tek kontrol ederiz.
        //Eğer Success dönmüyorsa metoddan çıkılır Şartı sağlamayan değer ile beraber çıkılır.
        //Eğer hepsi şartı sağlarsa null değer döner.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}

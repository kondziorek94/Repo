﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalWebApp.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public virtual Question Question { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
        public virtual List<Address> Adresses { get; set; }
    }
    public class AnswerComparer : IEqualityComparer<Answer>
    {
        private static readonly Lazy<AnswerComparer> lazy = new Lazy<AnswerComparer>(() => new AnswerComparer());
        public static AnswerComparer Instance { get { return lazy.Value; } }

        private AnswerComparer() { }

        public bool Equals(Answer x, Answer y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Answer obj)
        {
            return obj.GetHashCode();
        }
    }
}
//praca domowa
//1. przeczytac wymogi formalne stojace przed metoda GetHashCode
    //unequal objects may have same hashcode, how is it derived(pigeonhole principle)?
    //equal objects may have different hashcode, how is it compared? equal checks hashcode of both elements
    //must be random and constant for each object
    //implementation must be fast


//2. SINGLETON, zaimplementuj singleton PriceList1,2,3 na co najmniej 3 sposoby
    //is instance deleted when it finish its job?
    //class vs singleton.?number of objects inside
    //class eager loading; singleton -lazy loading
    //what is interface for? when class implements an interface, does it create all methods structures
    // or does it just force to write those methods

//3. zademonstruj dzialanie SelectMany, stworz klase Person ktora ma wlasciwosc typu List<int> ktora bedzie zawierac liczby
//   stworz liste obiektow klasy Person a nastepnie wydrukuj na konsole wszystkie liczby kazdej osoby bez uzycia petli
//   czyli Osoba1 ma liczby 3,5 ,7,9,9,5,6, Osoba 2 ma liczby 3,6
//   na kosnoli ma sie pojawic [3,5,7,9,9,5,6,3,6] w dowolnej kolejnosci tych liczb

    //   done

//4. w cshtml wyrenederuj zaznaczenie przyciskow radio button

    //5. sprawdzic baze danych
//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfPersonenverwaltungTest.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
        public string Plz { get; set; }
        public string Place { get; set; }
        public Nullable<int> AbteilungId { get; set; }
    
        public virtual Abteilung Abteilung { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirstOtherApproach.Designer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receipt
    {
        public System.Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Total { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
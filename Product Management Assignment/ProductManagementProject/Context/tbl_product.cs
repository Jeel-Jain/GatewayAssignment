//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductManagementProject.Context
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    
    public partial class tbl_product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<long> Quantity { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string smallImage { get; set; }
        public string longImage { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical_Assistant_System_v00
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emergency
    {
        public int Id_Emergency { get; set; }
        public string Phone_Number { get; set; }
        public string Message { get; set; }
        public int Id_Patient { get; set; }
    
        public virtual P_Personal_Infomation P_Personal_Infomation { get; set; }
    }
}
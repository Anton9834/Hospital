//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reception
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int Doctor { get; set; }
        public string Patient { get; set; }
        public string Status { get; set; }
    
        public virtual Doctor Doctor1 { get; set; }
        public virtual Patient Patient1 { get; set; }
        public virtual Status Status1 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZadohinControl10.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Train
    {
        public Train()
        {
            this.Ucet = new HashSet<Ucet>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<int> idFloorFlight { get; set; }
    
        public virtual FloorFlight FloorFlight { get; set; }
        public virtual ICollection<Ucet> Ucet { get; set; }
    }
}

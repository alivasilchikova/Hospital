//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalApp
{

    public partial class Bill
    {
        public System.Guid Id { get; set; }
        public System.Guid AppointmentId { get; set; }
        public System.Guid ServiceId { get; set; }
    
        public virtual Appointment Appointment { get; set; }
        public virtual Service Service { get; set; }
    }
}

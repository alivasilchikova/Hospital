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

    public partial class Schedule
    {
        public System.Guid Id { get; set; }
        public System.Guid DoctorId { get; set; }
        public string WeekDay { get; set; }
        public System.DateTime DayBegin { get; set; }
        public System.DateTime DayEnd { get; set; }
    
        public virtual Doctor Doctor { get; set; }
    }
}

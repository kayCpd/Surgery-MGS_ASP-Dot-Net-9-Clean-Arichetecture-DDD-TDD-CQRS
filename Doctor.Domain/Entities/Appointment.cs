using Surgery.Domain.Enums;
using Surgery.Domain.Exceptions;
using Surgery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surgery.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid GPOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public TimeInterval TimeInterval { get; private set; }
        public Patient? Patient { get; private set; }
        public Doctor? Doctor { get; private set; }
        public GPOffice? GPOffice { get; private set; }

        public Appointment(Guid patientId, Guid doctorId, Guid gpOfficeId, TimeInterval timeInterval)
        {
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException($"The start time cannot be in the past");
            }

            PatientId = patientId;
            DoctorId = doctorId;
            GPOfficeId = gpOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();

        }

        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
               throw new BusinessRuleException("Only scheduled appointments can be cancelled");
            }

            Status = AppointmentStatus.Cancelled;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be completed");
            }

            Status = AppointmentStatus.Completed;
        }
    }
}

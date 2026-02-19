using Surgery.Domain.Entities;
using Surgery.Domain.Enums;
using Surgery.Domain.Exceptions;
using Surgery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorMgs.Test.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _doctorId = Guid.NewGuid();
        private Guid _gpOfficeId = Guid.NewGuid();
        private TimeInterval _interval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            var appointment = new Appointment(_patientId, _doctorId, _gpOfficeId, _interval);

            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_doctorId, appointment.DoctorId);
            Assert.AreEqual(_gpOfficeId, appointment.GPOfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_StartTimeInThePast_Throws()
        {
            var interval = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            new Appointment(_patientId, _doctorId, _gpOfficeId, interval);
        }

        [TestMethod]
        public void Cancel_CancellingAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(_patientId, _doctorId, _gpOfficeId, _interval);
            appointment.Cancel();
            Assert.AreEqual(AppointmentStatus.Cancelled, appointment.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Cancel_CancellingAppointment_ThrowsIfStatusIsNotScheduled()
        {
            var appointment = new Appointment(_patientId, _doctorId, _gpOfficeId, _interval);
            appointment.Cancel();
            appointment.Cancel();
        }

        [TestMethod]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            var appointment = new Appointment(_patientId, _doctorId, _gpOfficeId, _interval);
            appointment.Complete();
            Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Complete_CompletingAppointment_ThrowsIfStatutsIsNotScheduled()
        {
            var appointment = new Appointment(_patientId, _doctorId, _gpOfficeId, _interval);
            appointment.Cancel();
            appointment.Complete();
        }
    }
}
